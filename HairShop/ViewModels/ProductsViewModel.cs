using HairShop.Models;
using HairShop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HairShop.ViewModels
{
    class ProductsViewModel : INotifyPropertyChanged
    {
        private DBOperations db;
      
        public ObservableCollection<ProductModel> prodcts { get; set; }
        public ObservableCollection<BrandModel> Brands { get; set; }
        public ObservableCollection<Product_TypeModel> prTypes { get; set; }

        private Products products;     
     

        public ProductsViewModel(Products products)
        {
            db = new DBOperations();
         
            prodcts = new ObservableCollection<ProductModel>(db.GetAllProducts());
            Brands = new ObservableCollection<BrandModel>(db.GetBrands());
            prTypes = new ObservableCollection<Product_TypeModel>(db.GetTypes());
            this.products = products;
        }
                
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
