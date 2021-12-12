using HairShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.ViewModels
{
   public  class ProductFilterViewModel
    {
        public bool ByName { get; set; }
        public bool ByBrand { get; set; }
        public bool ByHairType { get; set; }
        public bool ByProductType { get; set; }

        public string Name { get; set; }
        public Hair_TypeModel HairType { get; set; }
        public Product_TypeModel ProductType { get; set; }
        public BrandModel Brand { get; set; }
    }
}
