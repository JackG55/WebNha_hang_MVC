using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        private Model1 context = new Model1();
        // GET: Home
        public ActionResult Index()
        {
            var model = context.Bans.ToList();
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult menu()
        {
            return View();
        }

        public ActionResult table()
        {
            var model = context.Bans.ToList();
            ViewBag.MaBan = (Convert.ToInt32(context.Database.SqlQuery<string>("SELECT MAX(MaBan) FROM dbo.Ban").FirstOrDefault())+1).ToString();
            return View(model);
        }


        [HttpPost]
        public ActionResult them_ban(Ban ban)
        {
            try
            {
                //them vao bang ban 
                var obj = new Ban();
                obj.MaBan = ban.MaBan;
                obj.TenBan = ban.TenBan;
                obj.TrangThai = 0;
                obj.Vitri = ban.Vitri;

                context.Bans.Add(obj);
                context.SaveChanges();

                //them vao bang ban _ hoa don
                var b_hd = new Ban_HoaDon();
                b_hd.MaBan = ban.MaBan;

                context.Ban_HoaDon.Add(b_hd);
                context.SaveChanges();


                //them vao bang thong tin nguoi quan ly 
                var tt_ql = new ThongTinNguoiQuanLy();
                tt_ql.TenDangNhap = ban.MaBan;
                tt_ql.HoTen = ban.TenBan;
                context.ThongTinNguoiQuanLies.Add(tt_ql);
                context.SaveChanges();



                //them vao bang quan ly
                var ql = new QuanLy();
                ql.TenDangNhap = ban.MaBan;
                ql.MatKhau = "1";
                context.QuanLies.Add(ql);
                context.SaveChanges();

                var model = context.Bans.ToList();
                return View("table",model);
            }
            catch
            {
                var model = context.Bans.ToList();
                return View("table",model);
            }
        }



        public ActionResult client()
        {
            var model = context.PhanHois.ToList();
            return View(model);
        }


        public ActionResult edit_phan_hoi(string id)
        {
            PhanHoi ph = context.PhanHois.SingleOrDefault(s => s.MaPhanHoi == id);
            if (ph.TrangThai == 1)
            {
                ph.TrangThai = 0;
            }
            else if (ph.TrangThai == 0)
            {
                ph.TrangThai = 1;
            }

            context.SaveChanges();
            return View();
        }
        
        public ActionResult change_status(string maban)
        {

            //doi trang thai ban 
            Ban b = context.Bans.SingleOrDefault(s => s.MaBan == maban);
            b.TrangThai = 1;

            context.SaveChanges();

            int ma_hoa_don = context.Database.SqlQuery<int>("SELECT MAX(MaHoaDon) FROM dbo.HoaDon").FirstOrDefault() + 1;

            //ghi vao bang Hoadon
            var hoa_don_moi = new HoaDon();
            hoa_don_moi.MaHoaDon = ma_hoa_don;
            hoa_don_moi.GioVao = System.DateTime.Now;

            //them nguoi lap vao day 

            hoa_don_moi.TrangThai = 0;

            context.HoaDons.Add(hoa_don_moi);

            //ghi vao bang Ban_Hoadon
           

            Ban_HoaDon ban_hien_tai = context.Ban_HoaDon.SingleOrDefault(s => s.MaBan == maban);
            ban_hien_tai.MaBan = maban;
            ban_hien_tai.MaHoaDon = ma_hoa_don;
            ban_hien_tai.GioVao = hoa_don_moi.GioVao;

            context.SaveChanges();

           

            
            var model = context.Bans.ToList();
            return View("Index", model);
        }
    }
}
