namespace DAL.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=shopContext")
        {
        }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Check> Check { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Hair_Type> Hair_Type { get; set; }
        public virtual DbSet<Line_of_supply> Line_of_supply { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Product_Type> Product_Type { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Check>()
                .Property(e => e.total_price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Check>()
                .HasMany(e => e.Product)
                .WithMany(e => e.Check)
                .Map(m => m.ToTable("Line_of_check").MapLeftKey("Check_ID").MapRightKey("Product_ID"));

            modelBuilder.Entity<Hair_Type>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Hair_Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Line_of_supply>()
                .Property(e => e.purchasing_price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.unit_price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Line_of_supply)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product_Type>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Product_Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Supply)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supply>()
                .HasMany(e => e.Line_of_supply)
                .WithRequired(e => e.Supply)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Check)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Supply)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
