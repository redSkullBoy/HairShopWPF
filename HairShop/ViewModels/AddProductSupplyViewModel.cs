using DAL.Entity;
using HairShop.Models;
using HairShop.Services;
using HairShop.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HairShop.ViewModels
{
    class AddProductSupplyViewModel : INotifyPropertyChanged
    {
        private DBOperations db;

        private AddProductSupply addproductsupply;
        public AddProductSupplyViewModel(AddProductSupply addproductsupply)
        {
            this.addproductsupply = addproductsupply;

            db = new DBOperations();

            Supply_ID = Swapper.SupplyID;
            Product_ID = Swapper.ProductID;
            Product_Name = Swapper.ProductName;

        }

        private int Supply_ID;

        private int product_id;
        public int Product_ID
        {
            get { return product_id; }
            set { product_id = value; }
        }
        private string product_name;
        public string Product_Name
        {
            get { return product_name; }
            set { product_name = value; }
        }
        private int product_quantity;
        public int Product_Quantity
        {
            get { return product_quantity; }
            set { product_quantity = value; }
        }
        private decimal producy_price;
        public decimal Product_Price
        {
            get { return producy_price; }
            set { producy_price = value; }
        }


        private ReCommand close;
        public ReCommand Close_Win //закрытие окна
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      addproductsupply.Close();
                  }));
            }
        }


        private ReCommand add_product_supply;
        public ReCommand Add_Product_Supply //добавление товара в поставку
        {
            get
            {
                return add_product_supply ??
                  (add_product_supply = new ReCommand(obj =>
                  {
                      Line_of_supply los0 = db.GetLineOfSupply(Supply_ID, Product_ID);
                      if (los0 != null)
                      {
                          Product_Quantity += los0.Product_Quantity;
                          db.RemoveLineOfSupplies(los0);
                      }
                      Line_of_supply los = new Line_of_supply();
                      los.Supply_ID = Supply_ID;
                      los.Product_ID = Product_ID;
                      los.Product_Quantity = Product_Quantity;
                      los.purchasing_price = Product_Price;
                      db.AddLineOfSupplies(los);
                      addproductsupply.Close();
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
