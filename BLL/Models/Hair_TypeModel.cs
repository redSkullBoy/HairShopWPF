using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
    public class Hair_TypeModel
    {
        public int Hair_Type_ID { get; set; }
        public string Hair_Type_Name { get; set; }

        public Hair_TypeModel() { }
        public Hair_TypeModel(Hair_Type ht)
        {
            Hair_Type_ID = ht.Hair_Type_ID;
            Hair_Type_Name = ht.Hair_Type_Name;
        }
    }
}
