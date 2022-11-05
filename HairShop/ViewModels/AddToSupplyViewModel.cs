using HairShop.Models;
using HairShop.Services;
using HairShop.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.ViewModels
{
    class AddToSupplyViewModel : INotifyPropertyChanged
    {
        private DBOperations db;

        private AddToSupply addtosupply;
        public AddToSupplyViewModel(AddToSupply addtosupply)
        {
            this.addtosupply = addtosupply;

            db = new DBOperations();

            ProductTypes = new ObservableCollection<ProductTypeModel>(db.GetProductTypes());
            HairTypes = new ObservableCollection<HairTypeModel>(db.GetHairTypes());
            Brands = new ObservableCollection<BrandModel>(db.GetBrands());
            FilteredProducts = new ObservableCollection<ProductModel>(db.GetFilteredProduct());

            Supply_ID = Swapper.SupplyID;

        }

        public int Supply_ID;

        public ObservableCollection<BrandModel> Brands { get; set; }
        public ObservableCollection<HairTypeModel> HairTypes { get; set; }
        public ObservableCollection<ProductTypeModel> ProductTypes { get; set; }
        public ObservableCollection<ProductModel> FilteredProducts { get; set; }


        private ProductModel selectedProduct;
        public ProductModel SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
            }
        }


        private ProductTypeModel selectedProductType;
        public ProductTypeModel SelectedProductType
        {
            get { return selectedProductType; }
            set { selectedProductType = value; }
        }

        private HairTypeModel selectedHairType;
        public HairTypeModel SelectedHairType
        {
            get { return selectedHairType; }
            set { selectedHairType = value; }
        }

        private BrandModel selectedBrand;
        public BrandModel SelectedBrand
        {
            get { return selectedBrand; }
            set { selectedBrand = value; }
        }

        private string productNameTemplate;
        public string ProductNameTemplate
        {
            get { return productNameTemplate; }
            set { productNameTemplate = value; }
        }


        private ReCommand close;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      addtosupply.Close();
                  }));
            }
        }


        private ReCommand select;
        public ReCommand Select_Product //фильтрация
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
        public ReCommand Clear_Filter //сброс фильтрации
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


        private ReCommand create_product;
        public ReCommand Create_Product //нажата кнопка "добавить"
        {
            get
            {
                return create_product ??
                  (create_product = new ReCommand(obj =>
                  {
                      CreateProduct frm = new CreateProduct();
                      frm.ShowDialog();

                      addtosupply.Close();
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
