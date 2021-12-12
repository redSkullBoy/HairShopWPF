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

       // private readonly ObservableCollection<ProductsViewModel> _productsViewModel;
        public ObservableCollection<ProductModel> prodcts { get; set; }
        public ObservableCollection<BrandModel> Brands { get; set; }
        public ObservableCollection<Product_TypeModel> prTypes { get; set; }

        private Products products;
        private string _textToFilter;

        public string TextToFilter
        {
            get { return _textToFilter; }
            set
            {
                _textToFilter = value;
                ProductsCollection = null;
                OnPropertyChanged(nameof(TextToFilter));
                ProductsCollection.Refresh();
            }
        }

        private ICollectionView _productsCollection;

        public ICollectionView ProductsCollection
        {
           get { return _productsCollection; }
            set { _productsCollection = value; }
        }

        public ProductsViewModel(Products products)
        {
            db = new DBOperations();

           // _productsViewModel = new ObservableCollection<ProductsViewModel>();        
           
            ProductsCollection = CollectionViewSource.GetDefaultView(prodcts);
            prodcts = new ObservableCollection<ProductModel>(db.GetAllProducts());
            Brands = new ObservableCollection<BrandModel>(db.GetBrands());
            prTypes = new ObservableCollection<Product_TypeModel>(db.GetTypes());
            this.products = products;
            ProductsCollection.Filter = FilterByName;
        }

        //private IEnumerable<ProductsViewModel> GetProductsViewModels();

        private bool FilterByName(object pr)
        {
            if (!string.IsNullOrEmpty(TextToFilter))
            {
                var prModel = pr as ProductModel;
                return prModel != null && prModel.Product_Name.Contains(TextToFilter);
            }
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
