namespace ShopBanHang.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SizeProduct")]
    public partial class SizeProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SizeProduct()
        {
            Historyies = new HashSet<Historyy>();
        }

        [Key]
        public int ID_Size { get; set; }

        public int? ID_Product { get; set; }

        public int? Amount_Sold { get; set; }

        public int? Amount_Product { get; set; }

        [StringLength(8)]
        public string Size_Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Historyy> Historyies { get; set; }

        public virtual Product Product { get; set; }
    }
}
