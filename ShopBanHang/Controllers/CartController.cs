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
    }
}