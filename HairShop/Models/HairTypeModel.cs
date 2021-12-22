using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace HairShop.Models
{
    public class HairTypeModel
    {
        public int Hair_Type_ID { get; set; }
        public string Hair_Type_Name { get; set; }

        public HairTypeModel() { }
        public HairTypeModel(Hair_Type ht)
        {
            Hair_Type_ID = ht.Hair_Type_ID;
            Hair_Type_Name = ht.Hair_Type_Name;
        }
    }
}
