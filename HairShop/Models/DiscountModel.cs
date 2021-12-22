using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
    public class DiscountModel
    {
        public int Discount_ID { get; set; }
        public string Discount_Name { get; set; }
        public int Discount_amount { get; set; }
        public DateTime D_Start { get; set; }
        public DateTime D_End { get; set; }
        public int? Product_Type_ID { get; set; }
        public int? Brand_ID { get; set; }
        public DiscountModel() { }

        public DiscountModel(Discount discount)
        {
            Discount_ID = discount.Discount_ID;
            Discount_Name = discount.Discount_Name;
            Discount_amount = discount.Discount_amount;
            D_Start = discount.D_Start;
            D_End = discount.D_End;
            Product_Type_ID = discount.Product_Type_ID;
            Brand_ID = discount.Brand_ID;
        }
    }
}
