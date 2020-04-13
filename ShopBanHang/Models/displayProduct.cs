using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBanHang.Models
{
    public class displayProduct
    {
        public int ID_Product { get; set; }
        public string Name_Product { get; set; }
        public string Image_Product { get; set; }
        public bool? Promotion_Product { get; set; }
        public string Description_Product { get; set; }
        public bool? New_Product { get; set; }
        public decimal? Current_Price { get; set; }
        public decimal? Promotion_Price { get; set; }
        public string Name_Category { get; set; }
    }
}