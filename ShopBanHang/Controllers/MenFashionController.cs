using ShopBanHang.Database;
using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Controllers
{
    public class MenFashionController : BaseController
    {
        // GET: MenFashion
        DatabaseContextt db = new DatabaseContextt();
        public ActionResult Index()
        {


            var MenProduct = (from p in db.Products
                           join c in db.Categories on p.ID_Category equals c.ID_Category
                           where c.Gender == true
                           select new displayProduct
                           {
                               ID_Product = p.ID_Product,
                               Name_Product = p.Name_Product,
                               Image_Product = p.Image_Product,
                               Current_Price = p.Current_Price,
                               New_Product = p.New_Product,
                               Promotion_Price = p.Promotion_Price,
                               Promotion_Product = p.Promotion_Product
                           }
                              ).ToList();
            ViewBag.Menproduct = MenProduct;
            return View();
        }
    }
}