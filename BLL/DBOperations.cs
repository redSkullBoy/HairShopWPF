using BLL.Interfaces;
using DAL.Entity;
using DAL.Interfaces;
using HairShop.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
    public class DBOperations : IDbCrud
    {
        IDbRepository dataBase;
        public DBOperations( IDbRepository repos)
        {
            dataBase = repos;
        }

        public void CreateCheck(CheckModel check)
        {
            throw new NotImplementedException();
        }

        public void CreateProduct(ProductModel product)
        {
            dataBase.Products.Create(new Product()
            {
                Product_ID = product.Product_ID,
                Product_Name = product.Product_Name,
                unit_price = product.unit_price,
                volume = product.volume,
                Brand_ID = product.Brand_ID,
                Hair_Type_ID = product.Hair_Type_ID,
                Product_Type_ID = product.Product_Type_ID,
                count_stock = product.count_stock
            });
            Save();
        }

        public void DeleteCheck(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<BrandModel> GetAllBrands()
        {
            return dataBase.Brands.GetList().Select(i => new BrandModel(i)).ToList();
        }

        public List<Hair_TypeModel> GetAllHairTypes()
        {
            return dataBase.HairTypes.GetList().Select(i => new Hair_TypeModel(i)).ToList();
        }

        public List<ProductModel> GetAllProducts()
        {
            return dataBase.Products.GetList().Select(i => new ProductModel(i)).ToList();
        }

        public List<Product_TypeModel> GetAllProductTypes()
        {
            return dataBase.PriductTypes.GetList().Select(i => new Product_TypeModel(i)).ToList();
        }

        public ProductModel GetProduct(int id)
        {
            return new ProductModel(dataBase.Products.GetItem(id));
        }

        public bool Save()
        {
            if (dataBase.Save() > 0) return true;
            return false;
        }

        public void UpdateCheck(CheckModel check)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
