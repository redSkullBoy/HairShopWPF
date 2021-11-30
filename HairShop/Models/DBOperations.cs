using DAL.Entity;
using HairShop.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
    public class DBOperations
    {
        private HairShopContext db;
        public DBOperations()
        {
            db = new HairShopContext();
            db.Product.Load();
        }

        public List<ProductModel> GetProducts()
        {
            return db.Product.ToList().Select(i => new ProductModel(i)).ToList();
        }

        public List<BrandModel> GetBrands()
        {
            return db.Brand.ToList().Select(i => new BrandModel(i)).ToList();
        }

        public static MakeBuy GetProduct (int brandID)
        {
            return db.Product.Join(db.Brand, a => a.Brand_ID, m => m.Brand_ID, (a, m) => a)
               //.Join(db.VehicleEquip, a => a.ModelFK, b => b.Id, (a, b) => a)
               .Where(i => i.Product_Type_ID == brandID)
               .Select(i => new ProductModel
               {
                   Product_ID = i.Product_ID,
                   Product_Name = i.Product_Name,
                   volume = i.volume
               }).FirstOrDefault();
        }
    }
}
