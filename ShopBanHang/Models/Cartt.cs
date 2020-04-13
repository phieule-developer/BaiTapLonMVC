using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBanHang.Models
{
    public class Cartt
    {
        public int ID_Product { get; set; }
        public string Name_Product { get; set; }
        public int? Amount_Product { get; set; }
        public string Image_Product { get; set; }
        public string Size_Product { get; set; }
        public decimal? Current_Price { get; set; }
        public int? ID_Order { get; set; }
        public decimal? Promotion_Price { get; set; }
        public string Name_Category { get; set; }
        public decimal Total
        {
            
            get {
                if (Current_Price != null && Amount_Product != null)
                    return (decimal)Current_Price * (decimal)Amount_Product;
                else
                    return 0;
                 }
            set { }

        }
    }
}