using ShopBanHang.Database;
using ShopBanHang.Models;
using ShopBanHang.SubClass;
using ShopBanHang.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace ShopBanHang.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        DatabaseContextt db = new DatabaseContextt();
        public ActionResult Index(int? page)
        {
            if (Xcookie.Instance.GetAdminCookie() != null)
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            if (page == null)
                page = 1;
                var product = (from p in db.Products
                               join c in db.Categories on p.ID_Category equals c.ID_Category
                               select new displayProduct
                               {
                                   ID_Product = p.ID_Product,
                                   Name_Product = p.Name_Product,
                                   Name_Category = c.Name_Category,
                                   Image_Product = p.Image_Product,
                                   Current_Price = p.Current_Price,
                                   New_Product = p.New_Product,
                                   Promotion_Price = p.Promotion_Price,
                                   Promotion_Product = p.Promotion_Product
                               }
                              ).OrderBy(o=>o.ID_Product).Skip((int)(page-1)*8).Take(8).ToList();
                ViewBag.product = product;
            
            return View();
        }
        public JsonResult Search()
        {
            var user = db.Products.OrderBy(o => o.ID_Product).Select(s=> new {
                ID_Product= s.ID_Product,
                Name_Product= s.Name_Product,
                Image_Product=s.Image_Product
            }).ToList();
            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}