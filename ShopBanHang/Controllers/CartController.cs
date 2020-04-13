using Newtonsoft.Json;
using ShopBanHang.Database;
using ShopBanHang.Models;
using ShopBanHang.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Controllers
{
    public class CartController : BaseController
    {
        DatabaseContextt db = new DatabaseContextt();
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(string id,string sizeProductt,int amount)
        //{
        //    int id_product = int.Parse(id);
        //    var product = (from p in db.Products
        //                   join c in db.Categories on p.ID_Category equals c.ID_Category
        //                   join sp in db.SizeProducts on p.ID_Product equals sp.ID_Product
        //                   where p.ID_Product == id_product
        //                   select new Cartt
        //                   {
        //                       ID_Product = p.ID_Product,
        //                       Current_Price = p.Current_Price,
        //                       Image_Product = p.Image_Product,
        //                       Name_Category = c.Name_Category,
        //                       Name_Product = p.Name_Product,
        //                       Size_Product = sizeProductt,
        //                       Amount_Product = amount,
        //                   }
        //                   ).FirstOrDefault();
        //    if(Session["Cart"] == null)
        //    {
        //        List<Cartt> cartt = new List<Cartt>();
        //        cartt.Add(product);
        //        Session["Cart"] = cartt;
        //    }
        //    else
        //    {
        //        foreach(var item in (List<Cartt>)Session["Cart"])
        //        {
        //            if(item.ID_Product == id_product && item.Size_Product == sizeProductt)
        //            {
        //                item.Amount_Product+=amount;
        //                return null;
        //            } 
        //        }
        //        List<Cartt> cartt = (List<Cartt>)Session["Cart"];
        //        cartt.Add(product);
        //        Session["Cart"] = cartt;
        //    }
        //    return View();
        //}
      
        //public ActionResult RemoveProduct(int ID,string size)
        //{
        //    List<Cartt> cartt = (List<Cartt>)Session["Cart"];
        //    Cartt c = cartt.Find(p => p.ID_Product == ID && p.Size_Product==size);
        //    cartt.Remove(c);
        //    return null;
        //}




        //public ActionResult changeAmount(string ID,string amount)
        //{
        //    int amountProduct = int.Parse(amount);
        //    int ID_Productt = int.Parse(ID);
        //    List<Cartt> cartt = (List<Cartt>)Session["Cart"];
        //    Cartt c = cartt.Find(q => q.ID_Product == ID_Productt);
        //    c.Amount_Product = amountProduct;
        //    decimal total = 0;
        //    foreach(var item in (List<Cartt>)Session["Cart"])
        //    {
        //        total +=(decimal) item.Amount_Product * (decimal)item.Current_Price;
        //    }
        //    return Json(total,JsonRequestBehavior.AllowGet);
        //}
    }
}