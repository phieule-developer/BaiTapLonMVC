using ShopBanHang.Areas.Admin.Models;
using ShopBanHang.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ShopBanHang.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShopBanHang.CustomAuthorizeAttribute;

namespace ShopBanHang.Areas.Admin.Controllers
{
    [CustomAuthorize(Name_Permission = "Admin")]
    public class HomeController : BaseController
    {

        // GET: Admin/Home
        DatabaseContextt db = new DatabaseContextt();
        
        public ActionResult Index()
        {
            DateTime dt = DateExtension.startdayOfweek(DateTime.Now,DayOfWeek.Monday);
            var amountOrder = db.Orders.Where(o => o.Date_Order >= dt).Count();
            ViewBag.amountOrder = amountOrder;
            var total = (from o in db.Orders
                         join od in db.Order_Detail on o.ID_Order equals od.ID_Order
                         where o.Date_Order >= dt
                         select od).Sum(m=>m.Current_Price * m.Amount_Product);
            ViewBag.total = total;
            return View();
        }
    }
}