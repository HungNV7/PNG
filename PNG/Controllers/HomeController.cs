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

        public ActionResult Search(string search, string categoryId = null)
        {
            if (string.IsNullOrEmpty(categoryId))
            {
                if (string.IsNullOrEmpty(search))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    search = search.Trim();
                    List<Product> list = ProductDAO.Instance.Search(search);
                    if (list.Count > 0)
                    {
                        ViewBag.Product = list;
                    }
                }
            }
            else
            {
                ViewBag.Product = ProductDAO.Instance.GetProduct(categoryId);
            }
            ViewBag.Category = CategoryDAO.Instance.GetAll();
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account account)
        {
            Account user = AccountDAO.Instance.CheckLogin(account);
            if(user == null)
            {
                TempData["LOGIN_FAIL"] = "Email or password is incorrect";
                return View();
            }
            Session["USER"] = user;
            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account account)
        {
                if (ModelState.IsValid)
            {
                if (AccountDAO.Instance.AddNewAccount(account))
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    return View();
                }
                
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home", null);
        }
    }
}