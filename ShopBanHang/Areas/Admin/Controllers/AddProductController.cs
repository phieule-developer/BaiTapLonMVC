using ShopBanHang.CustomAuthorizeAttribute;
using ShopBanHang.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Areas.Admin.Controllers
{
    [CustomAuthorize(Name_Permission = "Admin")]
    public class AddProductController : BaseController
    {
        // GET: Admin/AddProduct
        DatabaseContextt db = new DatabaseContextt();
        public ActionResult Index()
        {
            var category = db.Categories.ToList();
            ViewBag.category = category;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Product product,HttpPostedFileBase Image_Product,int sizeM,int sizeL,int sizeXL,int sizeXXL)
        {
           // THÊM VÀO BẢNG SẢN PHẨM
            Image_Product.SaveAs(Server.MapPath("/Areas/Admin/Content_Admin/img/"+Image_Product.FileName));
            product.Date_Post = DateTime.Now;
            product.Image_Product = "/Areas/Admin/Content_Admin/img/" + Image_Product.FileName;
            db.Products.Add(product);
            db.SaveChanges();
            // Thêm vào bảng kích thước
            SizeProduct sizeProduct = new SizeProduct();
            sizeProduct.ID_Product = product.ID_Product;
            // Thêm size M
            sizeProduct.Amount_Product = sizeM;
            sizeProduct.Size_Product = "M";
            sizeProduct.Amount_Sold = 0;
            db.SizeProducts.Add(sizeProduct);
            db.SaveChanges();
            // Thêm size L
            sizeProduct.Amount_Product = sizeL;
            sizeProduct.Size_Product = "L";
            sizeProduct.Amount_Sold = 0;
            db.SizeProducts.Add(sizeProduct);
            db.SaveChanges();
            // Thêm size XL
            sizeProduct.Amount_Product = sizeXL;
            sizeProduct.Size_Product = "XL";
            sizeProduct.Amount_Sold = 0;
            db.SizeProducts.Add(sizeProduct);
            db.SaveChanges();
            // Thêm size XXL
            sizeProduct.Amount_Product = sizeXXL;
            sizeProduct.Size_Product = "XXL";
            sizeProduct.Amount_Sold = 0;
            db.SizeProducts.Add(sizeProduct);
            db.SaveChanges();
           


            return View();
        }
        public JsonResult Fashion(string category)
        {
            int ID_Category = int.Parse(category);
            var gender = false;
            if (ID_Category == 1)
                gender = true;
            else
                gender = false;
            var product = db.Categories.Where(o => o.Gender == gender).Select(s=> new {
                ID_Category = s.ID_Category,
                Name_Category= s.Name_Category
            }
            ).ToList();
            return Json(product,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Product(string product)
        {
            
            var productt = int.Parse(product);
            var pro = db.Products.Where(o => o.ID_Category == productt).Select(s => new
            {
                ID_Product = s.ID_Product,
                Name_Product = s.Name_Product
            }).ToList();
            return Json(pro, JsonRequestBehavior.AllowGet);
        }
    }
}