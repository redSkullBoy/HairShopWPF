using DAL.Entity;
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
    class CreateProductViewModel : INotifyPropertyChanged
    {
        private DBOperations db;

        private CreateProduct createproduct;
        public CreateProductViewModel(CreateProduct createproduct)
        {
            this.createproduct = createproduct;

            db = new DBOperations();

            ProductTypes = new ObservableCollection<ProductTypeModel>(db.GetProductTypes());
            HairTypes = new ObservableCollection<HairTypeModel>(db.GetHairTypes());
            Brands = new ObservableCollection<BrandModel>(db.GetBrands());

            Supply_ID = Swapper.SupplyID;

        }

        private int Supply_ID;

        public ObservableCollection<BrandModel> Brands { get; set; }
        public ObservableCollection<HairTypeModel> HairTypes { get; set; }
        public ObservableCollection<ProductTypeModel> ProductTypes { get; set; }


        private string product_name;
        public string Product_Name
        {
            get { return product_name; }
            set { product_name = value; }
        }

        private int product_volume;
        public int Product_Volume
        {
            get { return product_volume; }
            set { product_volume = value; }
        }

        private int product_quantity;
        public int Product_Quantity
        {
            get { return product_quantity; }
            set { product_quantity = value; }
        }

        private decimal product_price;
        public decimal Product_Price
        {
            get { return product_price; }
            set { product_price = value; }
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


        private ReCommand close;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      createproduct.Close();
                  }));
            }
        }


        private ReCommand create_product;
        public ReCommand Create_Product
        {
            get
            {
                return create_product ??
                  (create_product = new ReCommand(obj =>
                  {
                      //сохранить новый товар 
                      int Prod_ID = db.GetNextProductID();
                      Product prod = new Product();
                      prod.Product_ID = Prod_ID;
                      prod.Product_Name = Product_Name;
                      prod.unit_price = Product_Price;
                      prod.count_stock = Product_Quantity;
                      prod.volume = Product_Volume;
                      prod.Brand_ID = SelectedBrand.Brand_ID;
                      prod.Hair_Type_ID = selectedHairType.Hair_Type_ID;
                      prod.Product_Type_ID = selectedProductType.Product_Type_ID;
                      db.AddProducts(prod);

                      //добавить в поставку
                      Line_of_supply los = new Line_of_supply();
                      los.Supply_ID = Supply_ID;
                      los.Product_ID = Prod_ID;
                      los.Product_Quantity = Product_Quantity;
                      los.purchasing_price = Product_Price;
                      db.AddLineOfSupplies(los);

                      createproduct.Close();
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
