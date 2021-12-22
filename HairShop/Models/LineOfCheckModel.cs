using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
    public class LineOfCheckModel
    {
        public int Check_ID { get; set; }
        public int Product_ID { get; set; }
        public int Product_Quantity { get; set; }

        public LineOfCheckModel() { }
        public LineOfCheckModel(Line_of_check lofcheck)
        {
            Check_ID = lofcheck.Check_ID;
            Product_ID = lofcheck.Product_ID;
            Product_Quantity = lofcheck.Product_Quantity;
        }
    }
}
