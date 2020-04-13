using ShopBanHang.CustomAuthorizeAttribute;
using ShopBanHang.Database;
using ShopBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Areas.Admin.Controllers
{
    [CustomAuthorize(Name_Permission = "Admin")]
    public class OrderedListController : BaseController
    {
        // GET: Admin/OrderedList
        DatabaseContextt db = new DatabaseContextt();
        public ActionResult Index()
        {
            var infoOrder = (from o in db.Orders
                             where o.Status == true
                             orderby o.ID_Order descending
                             select o
                            
                             ).ToList();
            ViewBag.infoOrder = infoOrder;
            return View();
        }
        public ActionResult DetailOrder(string ID_Order)  // Danh sách đơn hàng đang chờ
        {
            int id_Order = int.Parse(ID_Order);
            var OrderList = (from o in db.Orders
                             join od in db.Order_Detail on o.ID_Order equals od.ID_Order
                             where od.ID_Order == id_Order
                             select new ConfirmOrder
                             {
                                 Image_Product = od.Product.Image_Product,
                                 ID_Product = od.ID_Product,
                                 Amount_Product = od.Amount_Product,
                                 Current_Price = od.Current_Price,
                                 Size_Product=od.Size_Product,
                                 Status = o.Status,
                                 Name_Product = od.Product.Name_Product,
                                 Note = o.Note,
                                 Total = (decimal)od.Amount_Product * (decimal)od.Current_Price
                             }).ToList();
            var totalList = db.Order_Detail.Where(o => o.ID_Order == id_Order).Sum(o => o.Amount_Product * o.Current_Price);
            ViewBag.totalList = totalList;
            ViewBag.OrderList = OrderList;
            return View();
        }
    }
}