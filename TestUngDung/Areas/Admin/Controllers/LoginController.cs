using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using TestUngDung.Areas.Admin.Model;
using TestUngDung.Common;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModal user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var kq = dao.postLogin(user.UserName, Encryptor.EncryptMD5(user.Password));
                if (kq == 1)
                {
                    Session.Add(Constants.USER_SESSION, user.UserName);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập thất bại");
                }
            }
            return View("Index");
        }
    }
}