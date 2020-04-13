using ShopBanHang.Database;
using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Controllers
{
    public class DetailProductController : BaseController
    {
        // GET: DetailProduct
        DatabaseContextt db = new DatabaseContextt();
        public ActionResult Index(int ID)
        {
            if (ID == null)
            {
                ViewBag.product = null;
                return View();
            }
            var product = (from p in db.Products
                           join c in db.Categories on p.ID_Category equals c.ID_Category
                           where p.ID_Product == ID
                           select new displayProduct
                           {
                               ID_Product = p.ID_Product,
                               Name_Product = p.Name_Product,
                               Name_Category = c.Name_Category,
                               Image_Product = p.Image_Product,
                               Current_Price = p.Current_Price,
                               New_Product = p.New_Product,
                               Promotion_Price = p.Promotion_Price,
                               Promotion_Product = p.Promotion_Product,
                               Description_Product=p.Description_Product
                           }).ToList();

            var ID_Category = db.Products.Where(o => o.ID_Product == ID).FirstOrDefault().ID_Category;

            var relateProduct = (from p in db.Products
                                 where p.ID_Product != ID && p.ID_Category == ID_Category
                                 select p).ToList();
           
            var commentProduct = (from c in db.Comments
                                  where c.ID_Product == ID
                                  select c).OrderByDescending(o => o.ID_Comment).Take(3).ToList();



            ViewBag.product = product;
            ViewBag.relateProduct = relateProduct;
            ViewBag.comment = commentProduct;
            return View();
        }
        [HttpPost]
        public ActionResult CommentProduct(Comment cm)
        {
            cm.Date_Comment = DateTime.Now;
            db.Comments.Add(cm);
            db.SaveChanges();
            return RedirectToAction("Index", new { ID= cm.ID_Product});
        }
        
    }
}