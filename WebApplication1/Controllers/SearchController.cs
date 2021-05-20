using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class SearchController : Controller
    {
        private Model1 context = new Model1();
        // GET: Search
        public ActionResult KetQuaTimKiem(FormCollection fc)
        {
            string key = fc["txtTimKiem"].ToString();
            List<MonAn> monAns = context.MonAns.Where(n => n.TenMonAn.Contains(key)).ToList();
            if(monAns.Count==0)
            {
                ViewBag.ThongBao = "Tiếc quá, không tìm thấy sản phẩm nào";
                return ViewBag;
            }   
            return View();
        }
    }
}