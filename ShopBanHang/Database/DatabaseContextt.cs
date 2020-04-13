namespace ShopBanHang.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContextt : DbContext
    {
        public DatabaseContextt()
            : base("name=DatabaseContextt")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Detail_Per> Detail_Per { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Historyy> Historyies { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Order_Detail> Order_Detail { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<SizeProduct> SizeProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order_Detail>()
                .Property(e => e.Current_Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Order_Detail>()
                .Property(e => e.Size_Product)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Current_Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Promotion_Price)
                .HasPrecision(18, 0);
        }
    }
}
