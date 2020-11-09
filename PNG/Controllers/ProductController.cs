using PNG.Daos;
using PNG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNG.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.Product = ProductDAO.Instance.GetAllForAdmin();
            ViewBag.Category = CategoryDAO.Instance.GetAllForAdmin();
            return View();
        }

        public ActionResult Detail(string id)
        {
            Product p = ProductDAO.Instance.GetOneProduct(id);
            if(p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        public ActionResult Create()
        {
            List<Category> list = CategoryDAO.Instance.GetAll();
            Session["CategoryList"] = ToSelectList(list);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                if (ProductDAO.Instance.AddNewProduct(p))
                {
                    TempData["ADD_Product"] = "Add new product successfully!";
                }
            }
            
            return View();
        }


        [NonAction]
        public SelectList ToSelectList(List<Category> listCategory)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (Category c in listCategory)
            {
                list.Add(new SelectListItem()
                {
                    Text = c.CategoryName.ToString(),
                    Value = c.CategoryID.ToString()
                });
            }
            return new SelectList(list, "Value", "Text"); ;
        }

        public ActionResult Update(string id)
        {
            Product p = ProductDAO.Instance.GetOneProduct(id);
            var dictionary = new Dictionary<int, string>
                {
                    { 3, "Available" },
                    { 4, "Unavailable" }
                };

            Session["CATEGORY"] = new SelectList(dictionary, "Key", "Value");
            return View();
        }

        public ActionResult Delete(string id)
        {
            return RedirectToAction("Index", "Home", null);
        }
    }
}