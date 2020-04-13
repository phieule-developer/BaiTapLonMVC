using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBanHang.Models
{
    public class ConfirmOrder
    {
        public int ID_Order { get; set; }

        [StringLength(50)]
        public string ID_Member { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Address_Province { get; set; }

        public string Address_District { get; set; }

        public string Address_Detail { get; set; }

        public DateTime? Date_Order { get; set; }

        public DateTime? Date_Ship { get; set; }

        public string Note { get; set; }

        public bool? Status { get; set; }

        public int ID_Order_Detail { get; set; }

        public int? ID_Product { get; set; }

        public decimal? Current_Price { get; set; }

        public int? Amount_Product { get; set; }

        public string Name_Category { get; set; }

        public string Image_Product { get; set; }

        public string Name_Product { get; set; }

        public string Size_Product { get; set; }

        public decimal Total
        {

            get
            {
                if (Current_Price != null && Amount_Product != null)
                    return (decimal)Current_Price * (decimal)Amount_Product;
                else
                    return 0;
            }
            set { }

        }
    }
}