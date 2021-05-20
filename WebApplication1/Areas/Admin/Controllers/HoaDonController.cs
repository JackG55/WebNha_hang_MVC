using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class HoaDonController : Controller
    {

        private Model1 context = new Model1();
        // GET: HoaDon
        public ActionResult bill()
        {
            var model = context.HoaDons.ToList();
            return View(model);
        }

        public ActionResult billdetail(string maban)
        {
            //truy van de lay ra ma hoa don tu bang Ban-HoaDon
            int ma_hoa_don = context.Database.SqlQuery<int>("SELECT MaHoaDon FROM dbo.Ban_HoaDon WHERE MaBan = " + maban).FirstOrDefault();


            //truy van ra cac thong tin cua hoa don 
            var mon = context.Database.SqlQuery<DatMon_HoaDon_MonAn>("SELECT MaDatMon, DatMon.MaMonAn, TenMonAn, HinhAnh, SoLuong, MonAn.GiaMon,GiaKhuyenMai, DatMon.TrangThai FROM dbo.DatMon JOIN dbo.MonAn ON MonAn.MaMonAn = DatMon.MaMonAn WHERE MaHoaDon = " + ma_hoa_don).ToList();
            ViewBag.MaHoaDon = ma_hoa_don;

            return View(mon);
        }


        public ActionResult edit_trang_thai(int id)
        {
            DatMon dm = context.DatMons.SingleOrDefault(s => s.MaDatMon == id);
            if(dm.TrangThai == 1)
            {
                dm.TrangThai = 0;
            }
            else if(dm.TrangThai ==0)
            {
                dm.TrangThai = 1;
            }

            context.SaveChanges();

            return View();
        }

        public ActionResult Thanh_toan(int ma_hoa_don)
        {

            //truyen vao ma hoa don
            ViewBag.MaHoaDon = ma_hoa_don;

            //truyen vao tong tien
            int tong_tien = Convert.ToInt32(context.Database.SqlQuery<decimal>("SELECT SUM(SoLuong * GiaMon) FROM dbo.DatMon WHERE TrangThai = 1 AND   MaHoaDon = " + ma_hoa_don).FirstOrDefault());
            ViewBag.TongTien = tong_tien;
            return PartialView();
        }

        [HttpPost]
        public ActionResult Thanh_toan(HoaDon hoa_don)
        {
            try
            {

                //cap nhat hoa don
                var obj = context.HoaDons.SingleOrDefault(s => s.MaHoaDon == hoa_don.MaHoaDon);
                obj.GioRa = System.DateTime.Now;
                obj.TongTien = hoa_don.TongTien;
                obj.TrangThai = 1;

                context.SaveChanges();

                //cap nhat trang thai ban
                string ma_ban = context.Database.SqlQuery<string>("SELECT MaBan FROM dbo.Ban_HoaDon WHERE MaHoaDon =" + hoa_don.MaHoaDon).FirstOrDefault();
                var ban = context.Bans.SingleOrDefault(s => s.MaBan == ma_ban);
                ban.TrangThai = 0;

                context.SaveChanges();

                //cap nhat lai bang Ban_Hoa_don
                var ban_hd = context.Ban_HoaDon.SingleOrDefault(s => s.MaBan == ma_ban);
                ban_hd.GioVao = null;
                ban_hd.HoaDon = null;
                context.SaveChanges();


                return RedirectToAction("Index","AdminHome");
            }
            catch
            {
                return View();
            }
            
       
        }

        public ActionResult huy_mon(int id)
        {
            //tim ra ma ban truoc

            string ma_ban = context.Database.SqlQuery<string>("SELECT MaBan FROM	dbo.DatMon WHERE MaDatMon = " + id).FirstOrDefault();

            var mon = context.DatMons.SingleOrDefault(s => s.MaDatMon == id);
            context.DatMons.Remove(mon);
            context.SaveChanges();


            return Redirect("/Admin/HoaDon/billdetail?maban=" + ma_ban);

          
        }

        public ActionResult GetBill(int id)
        {

           var mon = context.Database.SqlQuery<DatMon_HoaDon_MonAn>("SELECT DatMon.MaHoaDon,MaBan, NguoiLapHoaDon, GioVao, GioRa, DatMon.MaMonAn, TenMonAn, HinhAnh, SoLuong, MonAn.GiaMon,GiaKhuyenMai,TongTien FROM dbo.DatMon JOIN dbo.MonAn ON MonAn.MaMonAn = DatMon.MaMonAn JOIN dbo.HoaDon ON HoaDon.MaHoaDon = DatMon.MaHoaDon WHERE HoaDon.MaHoaDon = " + id).ToList();
            return PartialView("_PartialBillDetail",mon);
        }
    }
}