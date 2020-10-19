using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MenuController : Controller
    {
        private Model1 context = new Model1();
        // GET: Menu

        public ActionResult Menu()
        {
            var danh_muc = context.LoaiMons.ToList();
            return View(danh_muc);
        }


        [ChildActionOnly]
        public ActionResult Mon_an(int maloaimon=1)
        {

            var mon_an = context.MonAns.Where(x => x.MaLoaiMon == maloaimon).ToList();
            return PartialView(mon_an);
        }




    }
}