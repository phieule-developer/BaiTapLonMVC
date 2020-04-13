using jdk.@internal.util.xml.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using static System.Net.WebRequestMethods;

namespace ShopBanHang.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                "~/Content/js/JavaScript.js"));
        }
    }
}