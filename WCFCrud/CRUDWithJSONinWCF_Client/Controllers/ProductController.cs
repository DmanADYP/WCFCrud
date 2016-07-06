using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDWithJSONinWCF_Client.Models;
using CRUDWithJSONinWCF_Client.ViewModels;

namespace CRUDWithJSONinWCF_Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductServiceClient psc = new ProductServiceClient();
            ViewBag.listProducts = psc.findAll();
            return View();
        }
    }
}