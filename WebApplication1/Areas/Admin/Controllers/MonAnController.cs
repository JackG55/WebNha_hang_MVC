using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.SqlClient;
using Microsoft.Ajax.Utilities;

namespace WebApplication1.Areas.Admin.Controllers
{
    public class MonAnController : Controller
    {
        private Model1 context = new Model1();
        // GET: MonAn
        public ActionResult Index()
        {
            var model = context.Database.SqlQuery<LoaiMon_SoLuong>("GetQuantityFood").ToList();
            return View(model);
        }

        public ActionResult GetFoodData(int id)
        {
            ViewBag.Data = id;
            return PartialView("_PartialMonAn", context.MonAns.Where(x => x.MaLoaiMon == id).ToList());
        }

        // GET: MonAn/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MonAn/Create
        public ActionResult Create_mon_an(int ma_loai_mon)
        {
            int a = context.Database.SqlQuery<int>("SELECT TOP 1 MaMonAn FROM dbo.MonAn ORDER BY MaMonAn DESC").FirstOrDefault();
            

           ViewBag.Data = ma_loai_mon;
           ViewBag.mamon = a+1;
            return PartialView();
        }

        // POST: MonAn/Create
        [HttpPost]
        public ActionResult Create_mon_an(MonAn mon)
        {
            try
            {
                // TODO: Add insert logic here
                var obj = new MonAn();
                obj.MaLoaiMon = mon.MaLoaiMon;
                obj.MaMonAn = mon.MaMonAn;
                obj.TenMonAn = mon.TenMonAn;
                obj.MoTa = mon.MoTa;
                obj.GiaMon = mon.GiaMon;
                obj.GiaKhuyenMai = mon.GiaKhuyenMai;
                if (mon.HinhAnh != null)
                {
                    obj.HinhAnh = mon.HinhAnh;
                }

                obj.DonViTinh = mon.DonViTinh;
                obj.NgayTao = System.DateTime.Now;
                obj.TrangThai = 1;

                context.MonAns.Add(obj);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MonAn/Edit/5                    //to display
        public ActionResult Edit_mon_an(int ma_mon_an)          
        {
            MonAn mon = context.MonAns.SingleOrDefault(s => s.MaMonAn == ma_mon_an);
            if(mon==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return PartialView(mon);
        }

        // POST: MonAn/Edit/5                  //to change
        [HttpPost]
        public ActionResult Edit_mon_an(MonAn mon)
        {
            try
            {
                var obj = context.MonAns.SingleOrDefault(s => s.MaMonAn == mon.MaMonAn);
                obj.TenMonAn = mon.TenMonAn;
                obj.MoTa = mon.MoTa;
                obj.GiaMon = mon.GiaMon;
                obj.GiaKhuyenMai = mon.GiaKhuyenMai;
                if(mon.HinhAnh!= null)
                {
                    obj.HinhAnh = mon.HinhAnh;
                }    
               
                obj.DonViTinh = mon.DonViTinh;


                context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MonAn/Delete/5
        public ActionResult Delete_mon_an(int ma_mon_an)
        {

            MonAn mon = context.MonAns.SingleOrDefault(s => s.MaMonAn == ma_mon_an);
            if (mon == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return PartialView(mon);
        }

        // POST: MonAn/Delete/5
        [HttpPost]
        public ActionResult Delete_mon_an(MonAn mon)
        {
            try
            {
                // TODO: Add delete logic here
                var obj = context.MonAns.SingleOrDefault(s => s.MaMonAn == mon.MaMonAn);
                context.MonAns.Remove(obj);

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }




        //LOAI MON AN

        //GET: MonAn/Create/1
        public ActionResult Create_loai_mon()
        {
            int a = context.Database.SqlQuery<int>("SELECT TOP 1 MaLoaiMon FROM dbo.LoaiMon ORDER BY MaLoaiMon DESC").FirstOrDefault();


            ViewBag.Data = a+1;
            return PartialView();
        }

        //POST: MonAn/Create/1
        [HttpPost]
        public ActionResult Create_loai_mon(LoaiMon loai)
        {
            try
            {
                var obj = new LoaiMon();
                obj.MaLoaiMon = loai.MaLoaiMon;
                obj.TenLoaiMon = loai.TenLoaiMon;
                obj.TieuDe = loai.TieuDe;
                obj.NgayTao = System.DateTime.Now;
                obj.TuKhoaTimKiem = loai.TuKhoaTimKiem;

                context.LoaiMons.Add(obj);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

            
        }

        //GET: LoaiMon/Edit/1
        public ActionResult Edit_loai_mon(int ma_loai_mon)
        {
            LoaiMon loai = context.LoaiMons.SingleOrDefault(s => s.MaLoaiMon == ma_loai_mon);
            if(loai==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return PartialView(loai);
        }

        //POST: LoaiMon/Edit/1
        [HttpPost]
        public ActionResult Edit_loai_mon(LoaiMon loai)
        {
            try
            {
                var obj = context.LoaiMons.SingleOrDefault(s => s.MaLoaiMon == loai.MaLoaiMon);

                obj.TenLoaiMon = loai.TenLoaiMon;
                obj.TieuDe = loai.TieuDe;
                obj.TuKhoaTimKiem = loai.TuKhoaTimKiem;

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

            
        }


        //GET: LoaiMon/Delete/1
        public ActionResult Delete_loai_mon(int ma_loai_mon)
        {
            LoaiMon loai = context.LoaiMons.SingleOrDefault(s => s.MaLoaiMon == ma_loai_mon);
            if(loai==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return PartialView(loai);
        }


        //POST: LoaiMon/Delete/1
        [HttpPost]
        public ActionResult Delete_loai_mon(LoaiMon loai)
        {
            try
            {
                var obj = context.LoaiMons.SingleOrDefault(s => s.MaLoaiMon == loai.MaLoaiMon);
                if(obj!=null)
                {
                    context.LoaiMons.Remove(obj);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
