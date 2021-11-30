using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
    class CheckModel
    {
        public int Check_ID { get; set; }
        public DateTime? data_sale { get; set; }
        public decimal? total_price { get; set; }
        public int User_ID { get; set; }

        public CheckModel() { }
        public CheckModel(Check check)
        {
            Check_ID = check.Check_ID;
            data_sale = check.data_sale;
            total_price = check.total_price;
            User_ID = check.User_ID;
        }
    }
}
