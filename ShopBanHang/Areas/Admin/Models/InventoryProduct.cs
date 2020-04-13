using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBanHang.Areas.Admin.Models
{
    public class InventoryProduct
    {
        public int ID_Product { get; set; }
        public int ID_Size { get; set; }
        public string Name_Product { get; set; }
        public string Image_Product { get; set; }
        public int? Amount_Product { get; set; }
        public string Size_Number { get; set; }

    }
}