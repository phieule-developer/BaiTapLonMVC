using ShopBanHang.Areas.Admin.Models;
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
    public class InventoryController : BaseController
    {
        // GET: Admin/Inventory
        DatabaseContextt db = new DatabaseContextt();
        private Historyy history;


        // Hiển thị danh sách sản phẩm
        public ActionResult Index()
        {
            var listProduct = db.Products.ToList();
            ViewBag.listProduct = listProduct;
                       
            return View();
        }


        // Hiển thị danh sách kích cỡ của loại sản phẩm
        public ActionResult DetailProduct(int ID_Product)
        {
            var detailProduct = (from p in db.Products
                               join sp in db.SizeProducts on p.ID_Product equals sp.ID_Product
                               where p.ID_Product == ID_Product
                               select new InventoryProduct
                               {
                                   ID_Size = sp.ID_Size,
                                   Image_Product = p.Image_Product,
                                   ID_Product = p.ID_Product,
                                   Name_Product = p.Name_Product,
                                   Amount_Product = sp.Amount_Product,
                                   Size_Number = sp.Size_Product
                               }).ToList();
            ViewBag.detailProduct = detailProduct;
            return View();
        }



        // Cập nhật số lượng sản phẩm vào kho
        [HttpPost]
        public ActionResult AddProduct(int numProduct,int ID_Size)
        {
            // cập nhật số lượng
            db.SizeProducts.Where(o => o.ID_Size == ID_Size).FirstOrDefault().Amount_Product+=numProduct;
            var idProduct = db.SizeProducts.Where(o => o.ID_Size == ID_Size).FirstOrDefault().ID_Product;
            // Thêm vào bảng lịch sử
            history = new Historyy();
            history.Number_Product = numProduct;
            history.ID_Size = ID_Size;
            history.Add_Date = DateTime.Now;
            db.Historyies.Add(history);
            db.SaveChanges();
            return RedirectToAction("DetailProduct",new { ID_Product= idProduct });
        }


        // Lịch sử thêm sản phẩm
        public JsonResult Historyyy(string Id_Size)
        {
            int id_size = int.Parse(Id_Size);
            var listHistory = (from h in db.Historyies
                               where h.ID_Size == id_size
                               orderby h.ID_History descending
                               select new historyyy
                               {
                                   Number_Product=h.Number_Product,
                                   Add_Date=h.Add_Date
                               }
                               ).Take(5).ToList();
                              
            return Json(listHistory, JsonRequestBehavior.AllowGet);
        }


        // Hiển thị thông tin sản phẩm để chỉnh sửa
        public JsonResult getInfoProduct(int ID_Product)
        {
            var product = from p in db.Products
                          where p.ID_Product == ID_Product
                          select new EditProduct
                          {
                              ID_Product=p.ID_Product,
                              Name_Product=p.Name_Product,
                              Current_Price=p.Current_Price,
                              Description_Product=p.Description_Product,
                              New_Product=p.New_Product,
                              Promotion_Price=p.Promotion_Price
                          };
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        // Sửa sản phẩm
        public ActionResult EditProduct(Product product)
        {
            var prod = db.Products.Where(o => o.ID_Product == product.ID_Product).FirstOrDefault();
            prod.Name_Product = product.Name_Product;
            prod.Current_Price = product.Current_Price;
            prod.New_Product = product.New_Product;
            prod.Promotion_Price = product.Promotion_Price;
            prod.Description_Product = product.Description_Product;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}