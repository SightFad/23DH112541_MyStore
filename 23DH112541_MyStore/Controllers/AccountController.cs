using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using _23DH112541_MyStore.Models;
using _23DH112541_MyStore.Models.ViewModel;

namespace _23DH112541_MyStore.Controllers
{
    public class AccountController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.SingleOrDefault(u => u.Username == model.Username
                && u.Password == model.Password
                && u.UserRole == "Customer");
                if(user != null)
                {
                    // Lưu trạng thái đăng nhập vào session 
                    Session["Username"] = user.Username;
                    Session["UserRole"] = user.UserRole;

                    //lưu thông tin xác thực người dùng vào cookie
                    FormsAuthentication.SetAuthCookie(user.Username, false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }

            return View(model);
        }
    }
}