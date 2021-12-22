using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class CheckProduct
    {
        public int Check_ID { get; set; }
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Product_Quantity { get; set; }
        public decimal Product_Price { get; set; }
        public decimal Product_Summa { get; set; }
        public decimal Product_Discount { get; set; }
        public decimal Product_SumItog { get; set; }
    }
}
