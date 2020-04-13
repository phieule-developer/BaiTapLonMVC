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
    public class StatisticController : BaseController
    {
        DatabaseContextt db = new DatabaseContextt();
        // GET: Admin/Statistic
        // Thống kê sản phẩm theo tháng trong năm
        public ActionResult Index()
        {
           int cunrrentMonth= DateTime.Now.Month;
            DateTime dt = new DateTime(DateTime.Now.Year, 11, 1);
            var totalInMonth = (from q in db.Orders
                                join od in db.Order_Detail on q.ID_Order equals od.ID_Order
                                where q.Date_Order >= dt
                                select q).ToList();

            return View();
        }
    }
}