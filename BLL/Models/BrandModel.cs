using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
    public class BrandModel
    {
        public int Brand_ID { get; set; }
        public string Brand_Name { get; set; }
        public BrandModel() { }
        public BrandModel(Brand brand)
        {
            Brand_ID = brand.Brand_ID;
            Brand_Name = brand.Brand_Name;
        }
    }
}
