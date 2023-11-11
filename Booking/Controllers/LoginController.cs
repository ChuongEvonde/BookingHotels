using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Import thư viện Entity Framework hoặc ORM tương ứng

namespace Booking.Controllers
{
    public class LoginController : Controller
    {
        // Đây là đối tượng DbContext hoặc thứ tương tự để truy vấn cơ sở dữ liệu
        //private Booking_HotelsEntities  = new Booking();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public ActionResult Login()
        {
            /*var tendn = collection["username"];
            var matkhau = collection["password"];

            if (String.IsNullOrEmpty(tendn))
            {
                ViewBag.Loi1 = "Phải nhập tên đăng nhập";
            }
            else if (String.IsNullOrEmpty(matkhau))
            {
                ViewBag.Loi2 = "Phải nhập mật khẩu";
            }
            else
            {
                // Thực hiện xác thực với cơ sở dữ liệu
                var ad = db.Accounts.SingleOrDefault(n => n.UserName == tendn && n.Password == matkhau);

                if (ad != null)
                {
                    Session["Taikhoanadmin"] = ad;
                    return RedirectToAction("Index", "Admin");
                }
            }*/
            return View();
        }
    }
}
