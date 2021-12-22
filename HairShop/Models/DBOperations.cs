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
                //.Join(db.Product_Types, pr => pr.Product_Type_ID, prt => prt.Product_Type_ID, (pr, prt) => pr)
                .Where(i => (filter.Product_Name_Temp is null || i.Product_Name.ToLower().Contains(filter.Product_Name_Temp))
                    && (filter.Product_Type is null || i.Product_Type_ID == filter.Product_Type.Product_Type_ID)
                    && (filter.Hair_Type is null || i.Hair_Type_ID == filter.Hair_Type.Hair_Type_ID)
                    && (filter.Brand is null || i.Brand_ID == filter.Brand.Brand_ID))
                .Select(i => new ProductModel(i))
                .ToList();
            return result;
        }

    }
}
