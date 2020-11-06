using PNG.Daos;
using PNG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PNG.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Product = ProductDAO.Instance.GetAll();
            ViewBag.Category= CategoryDAO.Instance.GetAll();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search(string categoryId)
        {
            if (string.IsNullOrEmpty(categoryId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Category category = CategoryDAO.Instance.GetOneCategory(categoryId);
            if(category == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Product = ProductDAO.Instance.GetProduct(categoryId);
                ViewBag.Category = CategoryDAO.Instance.GetAll();
            }
            return View();
        }
    }
}