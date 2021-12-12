using DAL.Entity;


namespace DAL.Interfaces
{
   public interface IDbRepository
    {
        IRepository<Brand> Brands { get; }
        IRepository<Product> Products { get; }
        IRepository<Check> Checks { get; }
        IRepository<Discount> Discounts { get; }
        IRepository<Hair_Type> HairTypes { get; }
        IRepository<Line_of_supply> LineOfSupplies { get; }
        IRepository<Product_Type> PriductTypes { get; }
        IRepository<Supplier> Suppliers { get; }
        IRepository<Supply> Supplies { get; }     
        IServiceRepository Services { get; }
        int Save();
    }
}
