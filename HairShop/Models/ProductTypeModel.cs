﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entity;

namespace HairShop.Models
{
    public class ProductTypeModel
    {
        public int Product_Type_ID { get; set; }
        public string Product_Type_Name { get; set; }

        public ProductTypeModel() { }
        public ProductTypeModel(Product_Type pt)
        {
            Product_Type_ID = pt.Product_Type_ID;
            Product_Type_Name = pt.Product_Type_Name;
        }
    }
}
