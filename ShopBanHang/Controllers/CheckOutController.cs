using ShopBanHang.Database;
using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Controllers
{
    public class CheckOutController : BaseController
    {
        // GET: CheckOut
        DatabaseContextt db = new DatabaseContextt();
        public ActionResult Index() // Thông tin địa chỉ đơn hàng đơn hàng
        {
            var province = (from p in db.Provinces
                            select p).ToList();
            ViewBag.province = province;
            return View();
        }
        [HttpPost]
        public ActionResult Index(Order order)
        {
            order.Date_Order = DateTime.Now;
            int id_province = int.Parse(order.Address_Province);
            order.Address_Province = db.Provinces.Where(o => o.ID_Province == id_province).FirstOrDefault().Name_Province;
            order.Status = false;
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Detail_Order");
        }
        public ActionResult Detail_Order() // Chi tiết đơn hàng
        {

            //List<Cartt> ca = (List<Cartt>)Session["Cart"];
            //if (ca == null)
            //{
            //    ViewBag.detailOrder = ca;
            //    return View();
            //}
            //int? ID_Order = (int)ca[0].ID_Order;
            //var detailOrder = (from o in db.Orders
            //                   join od in db.Order_Detail on o.ID_Order equals od.ID_Order
            //                   join p in db.Products on od.ID_Product equals p.ID_Product
            //                   where o.ID_Order == ID_Order
            //                   select new ConfirmOrder
            //                   {
            //                       ID_Order= o.ID_Order,
            //                       Date_Order=o.Date_Order,
            //                       Address_Detail=o.Address_Detail,
            //                       Address_District=o.Address_District,
            //                       Address_Province=o.Address_Province,
            //                       Name_Product=p.Name_Product,
            //                       Amount_Product=od.Amount_Product,
            //                       Name=o.Name,
            //                       Size_Product=od.Size_Product,
            //                       Phone=o.Phone,
            //                       Current_Price=od.Current_Price,
            //                       Total=(decimal)od.Current_Price*(decimal)od.Amount_Product,
            //                       Note=o.Note
            //                   }).ToList();
            //ViewBag.detailOrder = detailOrder;
            //var total = db.Order_Detail.Where(o => o.ID_Order == ID_Order).Sum(o => o.Amount_Product * o.Current_Price);
            //ViewBag.total = total;
            return View();
        }
        [HttpPost]
        public ActionResult Detail_Order(string cart)
        {
            List<Order_Detail> a = null;
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public JsonResult District(string id_province)// load các huyện với tính tương ứng
        {
            int ID_Province = int.Parse(id_province);
            var district = (from d in db.Districts
                            where d.ID_Province == ID_Province
                            select new
                            {
                                Name_District = d.Name_District
                            }).ToList();
            return Json(district, JsonRequestBehavior.AllowGet);
        }
       
    }
}