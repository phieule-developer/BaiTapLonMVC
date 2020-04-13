using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Areas.Admin.Controllers
{
    public class UserListController : Controller
    {
        // GET: Admin/UserList
        public ActionResult Index()
        {
            return View();
        }
    }
}