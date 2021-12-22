using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class SupplyProduct
    {
        public int Supply_ID { get; set; }
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public int Product_Quantity { get; set; }
        public decimal Product_Price { get; set; }
    }
}
