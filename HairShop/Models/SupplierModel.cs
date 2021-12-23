using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.Models
{
   public class SupplierModel
    {
        public int Supplier_ID { get; set; }
        public string Supplier_Name { get; set; }
        public string Phonenumber { get; set; }
        public SupplierModel() { }
        public SupplierModel(Supplier supplier)
        {
            Supplier_ID = supplier.Supplier_ID;
            Supplier_Name = supplier.Supplier_Name;
            Phonenumber = supplier.Phonenumber;
        }
    }
}
