using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using ModelEF.Model;
using PagedList;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        private TraQuangLinh db = null;


        [HttpGet]
        public ActionResult Detail(int id)
        {
            var dao = new ProductDAO();
            var kq = dao.Find1(id);
            if (kq != null)
                return View(kq);
            return RedirectToAction("Index", "Product");
        }


        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var product = new ProductDAO();

            if (!string.IsNullOrEmpty(searchString))
            {
                var model = product.ListWhereAll(searchString, page, pageSize);
                ViewBag.SearchString = searchString;
                return View(model.ToPagedList(page, pageSize));
            }
            else
            {
                var model = product.ListAll();
                return View(model.ToPagedList(page, pageSize));
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {

            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                var kq = dao.Insert(product);
                if (kq == true)
                {
                    setAlert("Tạo mới sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    setAlert("Tạo mới sản phẩm không thành công", "error");
                    return RedirectToAction("Create", "Product");
                }
            }
            return View();
        }

        public void setViewBag(long? selectedId = null)
        {
            var dao = new CategoryDAO();
            ViewBag.CategoryList = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }
        [HttpDelete]
        public ActionResult Delete(string ID)
        {

            var dao = new ProductDAO();
            var respone = dao.Delete(int.Parse(ID));
            if (respone == true)
            {
                return RedirectToAction("Index", "SanPham");
            }
            else
            {
                return View();
            }
        }

    }
}