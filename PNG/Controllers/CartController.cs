using PNG.Daos;
using PNG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PNG.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Add(string id)
        {
            Cart cart = null;
            if(Session["CART"] == null)
            {
                cart = new Cart();
            }
            else
            {
                cart = Session["CART"] as Cart;
            }
            Product p = ProductDAO.Instance.GetOneProduct(id);

            cart.Add(p);
            Session["CART"] = cart;
            TempData["AddToCart"] = "Add " + p.ProductName + " successfully!";
            return RedirectToAction("Detail", "Product", new { id = id });
        }
    }
}