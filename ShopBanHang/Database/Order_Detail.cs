namespace ShopBanHang.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Detail
    {
        [Key]
        public int ID_Order_Detail { get; set; }

        public int? ID_Product { get; set; }

        public decimal? Current_Price { get; set; }

        public int? Amount_Product { get; set; }

        [StringLength(8)]
        public string Size_Product { get; set; }

        [StringLength(50)]
        public string Name_Category { get; set; }

        public int? ID_Order { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
