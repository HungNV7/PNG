using PNG.Daos;
using PNG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNG.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.Product = ProductDAO.Instance.GetAll();
            ViewBag.Category = CategoryDAO.Instance.GetAll();
            return View();
        }

        public ActionResult Category()
        {
            ViewBag.Category = CategoryDAO.Instance.GetAll();
            return View();
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            try
            {
                if (CategoryDAO.Instance.AddCategory(category))
                {
                    ViewBag.Message = "Add Successfully!";
                }
                else
                {
                    ViewBag.Message = "Add Unsuccessfully!";
                }
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Category");
            }
        }

        public ActionResult UpdateCategory(string categoryID)
        {
            Category cat = CategoryDAO.Instance.GetAll().Find(cate => cate.CategoryID.Equals(categoryID));
            return View(cat);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            try
            {
                if (CategoryDAO.Instance.UpdateCategory(category))
                {
                    ViewBag.Message = "Update Successfully!";
                }
                else
                {
                    ViewBag.Message = "Update Unsuccessfully!";
                }
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Category");
            }
        }

    }
}