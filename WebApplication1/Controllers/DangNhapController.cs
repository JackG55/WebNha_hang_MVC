using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class DangNhapController : Controller
    {
        private Model1 context = new Model1();
        public static string DangNhapSession = "DangNhapSession";
        // GET: DangNhap
        public ActionResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginForm(QuanLy acc)
        {
            string a = acc.TenDangNhap;
            string b = acc.MatKhau;

            if (ModelState.IsValid)
            {
                if (Login(acc.TenDangNhap, acc.MatKhau) == 2)  //admin
                {

                    //kiem tra vai tro

                    var ban = context.Bans.ToList();
                    return RedirectToAction("Index", "AdminHome", new { Area = "Admin" });
                }
                else if (Login(acc.TenDangNhap, acc.MatKhau) == 3)
                {
                  //  DangNhapSession[DangNhapSession] = 
                    return Redirect(@"~\Home\Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }


        }

        public int Login(string userName, string passWord)
        {
            var result = context.QuanLies.SingleOrDefault(x => x.TenDangNhap == userName);
            if (result == null)
            {
                return 0;   //ten dang nhap khong ton tai
            }
            else
            {
                if (result.MatKhau == passWord)
                {
                    if (result.VaiTro == "Admin")
                    {
                        Session[DangNhapSession] = result.TenDangNhap;
                        return 2;   ///admin
                    }
                    else if (result.VaiTro == "Client")
                    {
                        Session[DangNhapSession] = result.TenDangNhap;
                        return 3;   //client
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return -1; // sai mat khau
                }
            }

        }
    }
}