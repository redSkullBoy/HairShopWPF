using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
    public class ProductModel
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public decimal unit_price { get; set; }
        public int count_stock { get; set; }
        public int? volume { get; set; }
        public int Brand_ID { get; set; }
        public int Product_Type_ID { get; set; }
        public int Hair_Type_ID { get; set; }

        public ProductModel(/*Products products*/) { }
        public ProductModel(Product pr)
        {
            Product_ID = pr.Product_ID;
            Product_Name = pr.Product_Name;
            unit_price = pr.unit_price;
            count_stock = pr.count_stock;
            volume = pr.volume;
            Brand_ID = pr.Brand_ID;
            Product_Type_ID = pr.Product_Type_ID;
            Hair_Type_ID = pr.Hair_Type_ID;
        }
    }
}
