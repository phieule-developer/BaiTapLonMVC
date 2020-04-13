namespace ShopBanHang.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Historyy")]
    public partial class Historyy
    {
        [Key]
        public int ID_History { get; set; }

        public int? Number_Product { get; set; }

        public DateTime? Add_Date { get; set; }

        public int? ID_Size { get; set; }

        public virtual SizeProduct SizeProduct { get; set; }
    }
}
