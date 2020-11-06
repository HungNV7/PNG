using PNG.Daos;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        public ViewResult Search(string categoryId)
        {
            return View();
        }
    }
}