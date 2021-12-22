using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DAL.Entity;
using HairShop.View;
using HairShop.Models;
using System.Collections.ObjectModel;

namespace HairShop.ViewModels
{
    class MakeCheckViewModel : INotifyPropertyChanged
    {
        private ShopContext HairShop;
        private DBOperations db;

        private MakeCheck makecheck;
        public MakeCheckViewModel(MakeCheck makecheck)
        {
            this.makecheck = makecheck;
            HairShop = new ShopContext();

            db = new DBOperations();

            Brands = new ObservableCollection<BrandModel>(db.GetBrands());
            HairTypes = new ObservableCollection<HairTypeModel>(db.GetHairTypes());
            ProductTypes = new ObservableCollection<ProductTypeModel>(db.GetProductTypes());
            FilteredProducts = new ObservableCollection<ProductModel>(db.GetFilteredProduct());
        }

        private AddToCheck addtocheck;
        public MakeCheckViewModel(AddToCheck addtocheck)
        {
            MessageBox.Show("addtocheck " + this.selectedProductName);
            OnPropertyChanged("SelectedProductName");
            this.addtocheck = addtocheck;
            HairShop = new ShopContext();

            db = new DBOperations();
        }

        private ReCommand close;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      makecheck.Close();
                  }));
            }
        }

        private ReCommand select;
        public ReCommand Select_Product
        {
            get
            {
                return select ??
                  (select = new ReCommand(obj =>
                  {
                      FilterProductModel filter = new FilterProductModel(productNameTemplate, selectedBrand, selectedProductType, selectedHairType);
                      FilteredProducts = new ObservableCollection<ProductModel>(db.GetFilteredProduct(filter));
                      OnPropertyChanged("FilteredProducts");
                  }));
            }
        }

        private ReCommand clear;
        public ReCommand Clear_Filter
        {
            get
            {
                return clear ??
                  (clear = new ReCommand(obj =>
                  {
                      productNameTemplate = null;
                      OnPropertyChanged("productNameTemplate");
                      selectedProductType = null;
                      OnPropertyChanged("selectedProductType");
                      selectedHairType = null;
                      OnPropertyChanged("selectedHairType");
                      selectedBrand = null;
                      OnPropertyChanged("selectedBrand");
                      FilteredProducts = new ObservableCollection<ProductModel>(db.GetFilteredProduct());
                      OnPropertyChanged("FilteredProducts");
                  }));
            }
        }


        public ObservableCollection<BrandModel> Brands { get; set; }
        public ObservableCollection<HairTypeModel> HairTypes { get; set; }
        public ObservableCollection<ProductTypeModel> ProductTypes { get; set; }
        public ObservableCollection<ProductModel> FilteredProducts { get; set; }


        private string selectedProductName;
        public string SelectedProductName
        {
            get { return selectedProductName; }
            set
            {
                selectedProductName = value;
            }
        }

        private ProductModel selectedProduct;
        public ProductModel SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                selectedProductName = value.Product_Name;
            }
        }

        private BrandModel selectedBrand;
        public BrandModel SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                selectedBrand = value;
            }
        }

        private HairTypeModel selectedHairType;
        public HairTypeModel SelectedHairType
        {
            get { return selectedHairType; }
            set
            {
                selectedHairType = value;
            }
        }

        private ProductTypeModel selectedProductType;
        public ProductTypeModel SelectedProductType
        {
            get { return selectedProductType; }
            set
            {
                selectedProductType = value;
            }
        }

        private string productNameTemplate;
        public string ProductNameTemplate
        {
            get { return productNameTemplate; }
            set { productNameTemplate = value; }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
