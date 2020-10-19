using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NewController : Controller
    {
        private Model1 db = new Model1();
        // GET: New
        public ActionResult Index()
        {
            var mon_an = db.MonAns.ToList();
            return View(mon_an);
        }
    }
}