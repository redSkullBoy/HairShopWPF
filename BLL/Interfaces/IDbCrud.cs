using HairShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public interface IDbCrud
    {
        List<ProductModel> GetAllProducts();
        List<BrandModel> GetAllBrands();
        List<Hair_TypeModel> GetAllHairTypes();
        List<Product_TypeModel> GetAllProductTypes();
        ProductModel GetProduct(int id);
        void UpdateProduct(ProductModel product);
        void DeleteCheck(int id);  
        void CreateCheck(CheckModel check);
        void UpdateCheck(CheckModel check);
        void DeleteProduct(int id);
        void CreateProduct(ProductModel product);
        bool Save();
    }
}
