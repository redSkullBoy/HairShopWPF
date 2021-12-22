using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
    public class FilterProductModel
    {
        public string Product_Name_Temp { get; set; }
        public BrandModel Brand { get; set; }
        public ProductTypeModel Product_Type { get; set; }
        public HairTypeModel Hair_Type { get; set; }

        public FilterProductModel(string product_name_temp, BrandModel brand, ProductTypeModel product_type, HairTypeModel hair_type)
        {
            Product_Name_Temp = product_name_temp;
            Brand = brand;
            Product_Type = product_type;
            Hair_Type = hair_type;
        }
    }
}
