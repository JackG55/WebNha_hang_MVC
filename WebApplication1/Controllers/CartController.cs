using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;
using System.Web.Routing;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        private Model1 context = new Model1();
        private const string GioHangSession = "GioHangSession";
        // GET: Cart
        public ActionResult Index()
        {
            var giohang = Session[GioHangSession];
            var list = new List<GioHang>();
            if (giohang != null)
            {
                list = (List<GioHang>)giohang;
            }
            return View(list);
        }

        public ActionResult AddItem(int mamonan, int soluong, int trangthai, string thoigian)
        {
            var monan = context.MonAns.Find(mamonan);
            var giohang = Session[GioHangSession];
            if (giohang != null)
            {
                var list = (List<GioHang>)giohang;
                if (list.Exists(x => x.monAn.MaMonAn == mamonan)) // da co san
                {
                    foreach (var it in list)
                    {
                        if (it.monAn.MaMonAn == mamonan)
                        {
                            it.SoLuong += soluong;
                        }
                    }
                }
                else // chua co
                {
                    var it = new GioHang();
                    it.monAn = monan;
                    it.SoLuong = soluong;
                    it.TrangThai = trangthai;
                    list.Add(it);
                }
            }
            else
            {
                var item = new GioHang();
                item.monAn = monan;
                item.SoLuong = soluong;
                item.TrangThai = trangthai;
                var list = new List<GioHang>();
                list.Add(item);
                Session[GioHangSession] = list;
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddDatMon()
        {
            string maban = HttpContext.Session["DangNhapSession"].ToString();

            try
            {
                //lay ma hoa don
                var datmon_ban = context.Ban_HoaDon.Find(maban);
                int mahoadon = (int)datmon_ban.MaHoaDon;
                //lay danh sach cac mon can dat
                var giohang = Session[GioHangSession];

                //them vao bang dat mon
                if (giohang != null)
                {
                    var list = (List<GioHang>)giohang;
                    var listthemmoi = new List<GioHang>(list.FindAll(x => x.TrangThai == 0));
                    var listdadat = new List<GioHang>(list.FindAll(x => x.TrangThai == 1));
                    foreach (var it in listthemmoi)
                    {
                        var obj = new DatMon();
                        obj.MaBan = maban;
                        obj.MaHoaDon = mahoadon;
                        obj.MaDatMon = context.Database.SqlQuery<int>("SELECT MAX(MaDatMon) FROM dbo.DatMon").FirstOrDefault() + 1;
                        obj.SoLuong = it.SoLuong;
                        obj.TrangThai = 0;
                        obj.GiaMon = it.monAn.GiaMon;
                        obj.MaMonAn = it.monAn.MaMonAn;
                        obj.ThoiGian = DateTime.Now;
                        context.DatMons.Add(obj);
                        context.SaveChanges();
                        it.TrangThai = 1;
                        it.thoigiandathang = DateTime.Now.GetDateTimeFormats().ToString();
                    }
                    listthemmoi.AddRange(listdadat);
                    Session[GioHangSession] = listthemmoi;

                }
                //tra ve view
                return RedirectToAction("Index", Json(new { status = "success", message = "Thêm thành công" }));
            }
            catch (SqlException exs)
            {

                return Json(new { status = "error", message = "Dữ liệu đã tồn tại" });
            }
            catch (Exception ex)
            {

                return Json(new { status = "error", message = "Lỗi khi lưu" });
            }

        }
        public ActionResult HienThiMonTrongGioHang()
        {
            //lay mon an theo trang thai
            var giohang = Session[GioHangSession];
            List<GioHang> listmonan = new List<GioHang>();
            if (giohang != null)
            {
                var list = (List<GioHang>)giohang;
                foreach (GioHang it in list)
                {
                    if (it.TrangThai == 0)
                        listmonan.Add(it);
                }

            }
            //tra ve vew
            return PartialView("Partial_MonThemMoi", listmonan);

        }


        public ActionResult HuyMonAn(int mamonan)
        {
            var giohang = Session[GioHangSession];
            if (giohang != null)
            {
                var list = (List<GioHang>)giohang;
                var it = list.First(x => x.monAn.MaMonAn == mamonan);
                list.Remove(it);
                Session[GioHangSession] = list;
            }
            return RedirectToAction("HienThiMonTrongGioHang");
        }

        public ActionResult ThayDoiSoLuong(int soluong, int mamonan)
        {
            var giohang = Session[GioHangSession];
            if (giohang != null)
            {
                
                var list = (List<GioHang>)giohang;
                var it = list.First(x => x.monAn.MaMonAn == mamonan);
                int index = list.BinarySearch(it);
               // it.SoLuong = soluong;
                list.ElementAt(index).SoLuong = soluong;
               
                Session[GioHangSession] = list;

            }
            return RedirectToAction("HienThiMonTrongGioHang");
        }
        public ActionResult LayMonDaDat(string maban)
        {
            try
            {
                // lay dat mon theo ma ban va ma hoa don
                SqlParameter sqlParameter = new SqlParameter ("@maban", maban);
                return PartialView("Partial_MonDaDat", context.Database.SqlQuery<DatMon_Image>("LayDatMon @maban", sqlParameter).ToList());
            }
            catch (Exception ex)
            {
                return Json(new { status = "error", message = "Lỗi khi lưu" });
            }
            
        }
    }
}