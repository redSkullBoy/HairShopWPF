using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace HairShop.Models
{
    public class DBOperations
    {
        private ShopContext db;
        public DBOperations()
        {
            db = new ShopContext();
        }

        public List<BrandModel> GetBrands()
        {
            return db.Brands.ToList().Select(i => new BrandModel(i)).ToList();
        }

        public List<HairTypeModel> GetHairTypes()
        {
            return db.Hair_Types.ToList().Select(i => new HairTypeModel(i)).ToList();
        }

        public List<ProductTypeModel> GetProductTypes()
        {
            return db.Product_Types.ToList().Select(i => new ProductTypeModel(i)).ToList();
        }

        public List<ProductModel> GetFilteredProduct()
        {
            var result = db.Products.ToList().Select(i => new ProductModel(i)).ToList();
            return result;
        }

        public List<ProductModel> GetFilteredProduct(FilterProductModel filter)
        {
            var result = db.Products.ToList()               
                .Where(i => (filter.Product_Name_Temp is null || i.Product_Name.ToLower().Contains(filter.Product_Name_Temp))
                    && (filter.Product_Type is null || i.Product_Type_ID == filter.Product_Type.Product_Type_ID)
                    && (filter.Hair_Type is null || i.Hair_Type_ID == filter.Hair_Type.Hair_Type_ID)
                    && (filter.Brand is null || i.Brand_ID == filter.Brand.Brand_ID))
                .Select(i => new ProductModel(i))
                .ToList();
            return result;
        }

        public List<CheckProductModel> GetCheckProducts(int checkID)
        {
            var result = db.Checks
                .Join(db.Line_of_checks, ch => ch.Check_ID, loch => loch.Check_ID, (ch, loch) => new { ch, loch })
                .Join(db.Products, chl => chl.loch.Product_ID, pr => pr.Product_ID, (chl, pr) => new CheckProduct() { Check_ID = chl.ch.Check_ID, Product_ID = chl.loch.Product_ID, Product_Quantity = chl.loch.Product_Quantity, Product_Name = pr.Product_Name, Product_Price = pr.unit_price, Product_Summa = pr.unit_price * chl.loch.Product_Quantity, Product_Discount = 0, Product_SumItog = pr.unit_price * chl.loch.Product_Quantity - 0 })
                .ToList()
                .Where(i => i.Check_ID == checkID)
                .Select(i => new CheckProductModel(i))
                .ToList();
            return result;
        }

        public List<SupplyProductModel> GetSupplyProduct(int supplyID)
        {
            var result = db.Line_of_supplies
                .Join(db.Products, s => s.Product_ID, pr => pr.Product_ID, (s, pr) => new DAL.Entity.SupplyProduct() { Supply_ID = s.Supply_ID, Product_ID = s.Product_ID, Product_Name = pr.Product_Name, Product_Quantity = s.Product_Quantity, Product_Price = s.purchasing_price })
                .ToList()
                .Where(i => i.Supply_ID == supplyID)
                .Select(i => new SupplyProductModel(i))
                .ToList();
            return result;
        }

        public Product GetProduct(int productID)
        {
            return db.Products
                .Where(i => (i.Product_ID == productID)).First();
        }

        public int GetNextCheckID()
        {
            int? maxId = db.Checks.Max(u => (int?)u.Check_ID);
            int idNext = maxId == null ? 1 : ((int)maxId) + 1;
            return idNext;
        }

        public void AddChecks(Check check)
        {
            db.Checks.Add(check);
            db.SaveChanges();
        }

        public void AddLineOfChecks(Line_of_check loch)
        {
            db.Line_of_checks.Add(loch);
            db.SaveChanges();
        }

        public Line_of_check GetLineOfCheck(int checkID, int productID)
        {
            return db.Line_of_checks
                .Where(i => (i.Check_ID == checkID && i.Product_ID == productID)).First();
        }

        public void RemoveLineOfChecks(Line_of_check loch)
        {
            db.Line_of_checks.Remove(loch);
            db.SaveChanges();
        }

        public bool IsCheckExists(int checkID)
        {
            bool res = false;
            var checks = db.Checks.ToList()
                .Where(i => i.Check_ID == checkID)
                .Select(i => new CheckModel(i))
                .ToList();
            if (checks.Count > 0)
                res = true;
            return res;
        }

        public bool IsProductInCheck(int checkID, int productID)
        {
            bool res = false;
            var prods = db.Line_of_checks.ToList()
                .Where(i => (i.Check_ID == checkID && i.Product_ID == productID))
                .Select(i => new LineOfCheckModel(i))
                .ToList();
            if (prods.Count > 0)
                res = true;
            return res;
        }

        public int GetNextProductID()
        {
            int? maxId = db.Products.Max(u => (int?)u.Product_ID);
            int idNext = maxId == null ? 1 : ((int)maxId) + 1;
            return idNext;
        }

        public void AddProducts(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void DecreaseProduct(int productID, int quantity)
        {
            Product product = db.Products.Find(productID);
            if (product != null)
            {
                product.count_stock -= quantity;
                db.SaveChanges();
            }
        }

        public List<DiscountModel> GetDiscounts()
        {
            var result = db.Discounts.ToList().Select(i => new DiscountModel(i)).ToList();
            return result;
        }

        public List<DiscountModel> GetDiscountsByDateAndProdType(DateTime dateDiscount, int prodTypeID)
        {
            var result = db.Discounts.ToList()
                .Where(i => i.D_Start <= dateDiscount && i.D_End >= dateDiscount && (i.Product_Type_ID == null || i.Product_Type_ID == prodTypeID))
                .Select(i => new DiscountModel(i)).ToList();
            return result;
        }

        public int GetNextDiscountID()
        {
            int? maxId = db.Discounts.Max(u => (int?)u.Discount_ID);
            int idNext = maxId == null ? 1 : ((int)maxId) + 1;
            return idNext;
        }

        public void AddDiscounts(Discount discount)
        {
            db.Discounts.Add(discount);
            db.SaveChanges();
        }

        public Discount GetDiscount(int discountID)
        {
            return db.Discounts
                .Where(i => (i.Discount_ID == discountID)).First();
        }

        public void RemoveDiscounts(Discount dis)
        {
            db.Discounts.Remove(dis);
            db.SaveChanges();
        }

        public List<ProductReport> GetReportBestProducts(DateTime dateBeg, DateTime dateEnd)
        {
            List<ProductReport> prods = db.Products
                .Join(db.Line_of_checks, p => p.Product_ID, c => c.Product_ID, (p, c) => new ProductReport { Check_ID = c.Check_ID, Check_Date = DateTime.Now, Product_Name = p.Product_Name, Product_Quantity = c.Product_Quantity })
                .Join(db.Checks, pc => pc.Check_ID, ch => ch.Check_ID, (pc, ch) => new ProductReport { Check_ID = pc.Check_ID, Check_Date = (DateTime)ch.data_sale, Product_Name = pc.Product_Name, Product_Quantity = pc.Product_Quantity })
                .Where(pp => pp.Check_Date >= dateBeg && pp.Check_Date <= dateEnd)
                .ToList()
                .GroupBy(i => i.Product_Name)
                .Select(r => new ProductReport { Product_Name = r.First().Product_Name, Product_Quantity = r.Sum(c => c.Product_Quantity) })
                .OrderByDescending(r => r.Product_Quantity)
                .Take(10)
                .ToList();

            return prods;
        }

        public int GetNextSupplyID()
        {
            int? maxId = db.Supplies.Max(u => (int?)u.Supply_ID);
            int idNext = maxId == null ? 1 : ((int)maxId) + 1;
            return idNext;
        }

        public void AddSupplies(Supply supply)
        {
            db.Supplies.Add(supply);
            db.SaveChanges();
        }

        public void AddLineOfSupplies(Line_of_supply los)
        {
            db.Line_of_supplies.Add(los);
            db.SaveChanges();
        }

        public List<SupplierModel> GetSuppliers()
        {
            return db.Suppliers.ToList().Select(i => new SupplierModel(i)).ToList();
        }

        public int GetNextSupplierID()
        {
            int? maxId = db.Suppliers.Max(u => (int?)u.Supplier_ID);
            int idNext = maxId == null ? 1 : ((int)maxId) + 1;
            return idNext;
        }

        public void AddSuppliers(Supplier supplier)
        {
            db.Suppliers.Add(supplier);
            db.SaveChanges();
        }

        public Line_of_supply GetLineOfSupply(int supplyID, int productID)
        {
            Line_of_supply res = null;
            List<Line_of_supply> loss = db.Line_of_supplies.ToList()
                .Where(i => (i.Supply_ID == supplyID && i.Product_ID == productID)).ToList();
            if (loss.Count > 0)
            {
                res = loss.First();
            }
            return res;
        }

        public void RemoveLineOfSupplies(Line_of_supply los)
        {
            db.Line_of_supplies.Remove(los);
            db.SaveChanges();
        }

        public void ApplySupplyProducts(int productID, int quantity, decimal price)
        {
            Product product = db.Products.Find(productID);
            if (product != null)
            {
                product.count_stock += quantity;
                product.unit_price = price;
                db.SaveChanges();
            }
        }
    }
}
