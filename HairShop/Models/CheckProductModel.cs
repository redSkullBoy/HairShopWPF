using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
    public class CheckProductModel
    {
        public int Check_ID { get; set; }
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Product_Quantity { get; set; }
        public decimal Product_Price { get; set; }
        public decimal Product_Summa { get; set; }
        public decimal Product_Discount { get; set; }
        public decimal Product_SumItog { get; set; }

        public CheckProductModel() { }
        public CheckProductModel(CheckProduct checkproduct)
        {
            Check_ID = checkproduct.Check_ID;
            Product_ID = checkproduct.Product_ID;
            Product_Name = checkproduct.Product_Name;
            Product_Quantity = checkproduct.Product_Quantity;
            Product_Price = checkproduct.Product_Price;
            Product_Summa = checkproduct.Product_Summa;
            Product_Discount = checkproduct.Product_Discount;
            Product_SumItog = checkproduct.Product_SumItog;
        }
    }
}
