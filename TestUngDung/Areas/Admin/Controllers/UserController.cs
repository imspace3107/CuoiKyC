using ModelEF.DAO;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var user = new UserDAO();

            if (!string.IsNullOrEmpty(searchString))
            {
                var model = user.ListWhereAll(searchString, page, pageSize);
                ViewBag.SearchString = searchString;
                return View(model.ToPagedList(page, pageSize));
            }
            else
            {
                var model = user.ListAll();
                return View(model.ToPagedList(page, pageSize));
            }
        }
        [HttpDelete]
        public ActionResult Delete(string ID)
        {
            var respone = new UserDAO().PostDelete(int.Parse(ID));
            if (respone == true)
            {

                return RedirectToAction("Index", "User");
            }
            else
            {
                return View();
            }
        }
    }
}