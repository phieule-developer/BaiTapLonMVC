using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBanHang.Areas.Admin.Models
{
    public class EditProduct
    {
        public int ID_Product { get; set; }
        public string Name_Product { get; set; }

        public string Image_Product { get; set; }
        public string Description_Product { get; set; }
        public bool? New_Product { get; set; }

        public decimal? Current_Price { get; set; }

        public decimal? Promotion_Price { get; set; }

    }
}