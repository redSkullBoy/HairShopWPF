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
        private  HairShopContext db;
        public DBOperations()
        {
            db = new HairShopContext();
            db.Product.Load();
        }

        public List<ProductModel> GetAllProducts()
        {
            return db.Product.ToList().Select(i => new ProductModel(i)).ToList();
        }

        public List<BrandModel> GetBrands()
        {
            return db.Brand.ToList().Select(i => new BrandModel(i)).ToList();
        }

        public List<Hair_TypeModel> GetHairTypes()
        {
            return db.Hair_Type.ToList().Select(i => new Hair_TypeModel(i)).ToList();
        }

        public List<Product_TypeModel> GetTypes()
        {
            return db.Product_Type.ToList().Select(i => new Product_TypeModel(i)).ToList();
        }

        //    public static List<ProductModel> GetProduct (int brandID)
        //    {
        //        HairShopContext db = new HairShopContext();
        //        var request = db.Product
        //       .Join(db.Brand, a => a.Brand_ID, m => m.Brand_ID, (a, m) => a)              
        //           .Where(i => i.Product_Type_ID == brandID)
        //           .Select(i => new ProductModel
        //           {
        //               Product_ID = i.Product_ID,
        //               Product_Name = i.Product_Name,
        //               volume = i.volume
        //           }).ToList();
        //        return request;
        //    }
    }
}
