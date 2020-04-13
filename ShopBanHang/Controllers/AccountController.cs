using Facebook;
using ShopBanHang.Database;
using ShopBanHang.SubClass;
using ShopBanHang.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace ShopBanHang.Controllers
{
    public class AccountController : Controller
    {
        DatabaseContextt db = new DatabaseContextt();
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        [Obsolete]
        // GET: Account
        // Đăng nhập
        public ActionResult LogIn(SubAdmin ss,SubMember sm)
        {
            string password = FormsAuthentication.HashPasswordForStoringInConfigFile(ss.Password, "MD5");
            var member = db.Members.Where(o => o.Email == ss.Email && o.Password == password).FirstOrDefault();
            var admin = db.Admins.Where(o => o.Email == sm.Email && o.Password == password).FirstOrDefault();
            ViewBag.Message = null;
            if(member != null)
            {
                if (sm.CheckBox == "on")
                {
                    Xcookie.Instance.SetMember(AutoMapper.Mapper.Map<SubMember>(member));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Xsession.Member = AutoMapper.Mapper.Map<SubMember>(member);
                    return RedirectToAction("Index", "Home");
                }
            }
            else if(admin != null)
            {
                if (ss.CheckBox == "on")
                   
                {
                    Xcookie.Instance.SetAdmin(AutoMapper.Mapper.Map<SubAdmin>(admin));
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    Xsession.Admin = AutoMapper.Mapper.Map<SubAdmin>(admin);
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                
            }
            else
            {
                ViewBag.Message = "Tên đăng nhập hoặc mật khẩu không chính xác";
            }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [Obsolete]
        public ActionResult SignUp(SubMember sm)
        {
            if (sm.Password != sm.ConfirmPassword)
            {
                ViewBag.Error = "Mật khẩu và xác thực mật khẩu không khớp";
                return View();
            }
            else
            {
                sm.ID_Member = "" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
                sm.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(sm.Password, "MD5");
                db.Members.Add(AutoMapper.Mapper.Map<Member>(sm));
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult LogOut()
        {
            Xsession.RemoveAdmin();
            Xsession.RemoveMember();
            HttpContext.Session.Remove("Name");
            Xcookie.Instance.RemoveMember();
            Xcookie.Instance.RemoveAdmin();
            return RedirectToAction("Index", "Home");
        }

        private Uri RediredtUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new

            {
                client_id = "671405016679446",

                client_secret = "76492e781a86c400c63379bbdb429cb1",

                redirect_uri = RediredtUri.AbsoluteUri,

                response_type = "code",

                scope = "email"
            });
            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();

            dynamic result = fb.Post("oauth/access_token", new

            {

                client_id = "671405016679446",

                client_secret = "76492e781a86c400c63379bbdb429cb1",

                redirect_uri = RediredtUri.AbsoluteUri,

                code = code
            });

            var accessToken = result.access_token;

            Session["AccessToken"] = accessToken;
            fb.AccessToken = accessToken;
            dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,picture,age_range");
            string email = me.email;
            Session["Name"] =me.first_name+" "+me.last_name;
            FormsAuthentication.SetAuthCookie(email, false);
            return RedirectToAction("Index", "Home");
        }
    }

}
