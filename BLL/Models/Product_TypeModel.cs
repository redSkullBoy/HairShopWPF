using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
   public class Product_TypeModel
    {
        public int Product_Type_ID { get; set; }
        public string Product_Type_Name { get; set; }

        public Product_TypeModel() { }
        public Product_TypeModel(Product_Type pt)
        {
            Product_Type_ID = pt.Product_Type_ID;
            Product_Type_Name = pt.Product_Type_Name;
        }
    }
}
