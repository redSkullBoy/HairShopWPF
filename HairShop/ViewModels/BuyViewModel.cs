using HairShop.Models;
using HairShop.View;
//using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HairShop.ViewModels
{
    class BuyViewModel
    {
        private DBOperations db;
        public ObservableCollection<BrandModel> Brands { get; set; }
        public ObservableCollection<ProductModel> Products { get; set; }
        public BuyViewModel()
        {
            db = new DBOperations();
            Products = new ObservableCollection<ProductModel>(db.GetProducts());
            Brands = new ObservableCollection<BrandModel>(db.GetBrands());
        }
    }
}
