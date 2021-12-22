using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
    public class SupplyProductModel
    {
        public int Supply_ID { get; set; }
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Product_Quantity { get; set; }
        public decimal Product_Price { get; set; }

        public SupplyProductModel() { }
        public SupplyProductModel(SupplyProduct supplayproduct)
        {
            Supply_ID = supplayproduct.Supply_ID;
            Product_ID = supplayproduct.Product_ID;
            Product_Name = supplayproduct.Product_Name;
            Product_Quantity = supplayproduct.Product_Quantity;
            Product_Price = supplayproduct.Product_Price;
        }
    }
}
