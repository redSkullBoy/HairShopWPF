using HairShop.Models;
using HairShop.View;
using HairShop.ViewModels.Base;
//using DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HairShop.ViewModels
{
    class MakeBuyViewModel : ViewModel
    {
        private DBOperations db;

       // private ICommand _showFiltered;
        public ObservableCollection<BrandModel> Brands { get; set; }
        public ObservableCollection<ProductModel> Products { get; set; }
        public ObservableCollection<Hair_TypeModel> HairTypes { get; set; }
        public ObservableCollection<Product_TypeModel> prTypes { get; set; }
        //public ProductFilterViewModel ProductFilter { get; set; }
        public MakeBuyViewModel()
        {
            db = new DBOperations();
            Products = new ObservableCollection<ProductModel>(db.GetAllProducts());
            Brands = new ObservableCollection<BrandModel>(db.GetBrands());
            HairTypes = new ObservableCollection<Hair_TypeModel>(db.GetHairTypes());
            prTypes = new ObservableCollection<Product_TypeModel>(db.GetTypes());

        }
       

    }
}
