namespace ShopBanHang.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Comments = new HashSet<Comment>();
            Order_Detail = new HashSet<Order_Detail>();
            SizeProducts = new HashSet<SizeProduct>();
        }

        [Key]
        public int ID_Product { get; set; }

        [StringLength(50)]
        public string Name_Product { get; set; }

        public string Image_Product { get; set; }

        [StringLength(250)]
        public string Description_Product { get; set; }

        public bool? Promotion_Product { get; set; }

        public bool? New_Product { get; set; }

        public decimal? Current_Price { get; set; }

        public decimal? Promotion_Price { get; set; }

        public DateTime? Date_Post { get; set; }

        public int? ID_Category { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Detail> Order_Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SizeProduct> SizeProducts { get; set; }
    }
}
