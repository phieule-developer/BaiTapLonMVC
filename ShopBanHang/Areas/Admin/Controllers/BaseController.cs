using ShopBanHang.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBanHang.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Xsession.Admin == null)
            {
                if (Xcookie.Instance.GetAdminCookie() != null)
                    Xsession.Admin = Xcookie.Instance.GetAdminCookie();
            }
            base.OnActionExecuting(filterContext);
        }
    }
}