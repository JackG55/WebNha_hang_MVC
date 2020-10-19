using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private Model1 context = new Model1();

        public ActionResult Index()
        {
            var ds = context.PhanHois.ToList();
            return View(ds);
        }

        public ActionResult About()
        {

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

        public ActionResult Detail(string maPH)
        {
            PhanHoi ph = context.PhanHois.SingleOrDefault(n => n.MaPhanHoi == maPH);
            if(ph==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(ph);
        }
       

        
    }
}