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
    }
}