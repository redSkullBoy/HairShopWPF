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
    class SupplyProductViewModel : INotifyPropertyChanged
    {
        private DBOperations db;

        private HairShop.View.SupplyProduct supplyproduct;
        public SupplyProductViewModel(HairShop.View.SupplyProduct supplyproduct)
        {
            this.supplyproduct = supplyproduct;

            db = new DBOperations();

            Supply_ID = 0;

            SupplyProducts = new ObservableCollection<SupplyProductModel>(db.GetSupplyProduct(Supply_ID));
            Suppliers = new ObservableCollection<SupplierModel>(db.GetSuppliers());

            DateInvoice = DateTime.Now;

        }

        public int Supply_ID;

        public ObservableCollection<SupplyProductModel> SupplyProducts { get; set; }
        public ObservableCollection<SupplierModel> Suppliers { get; set; }

        private SupplierModel selectedSupplier;
        public SupplierModel SelectedSupplier
        {
            get { return selectedSupplier; }
            set
            {
                selectedSupplier = value;
            }
        }

        private string numberinvoice;
        public string NumberInvoice
        {
            get { return numberinvoice; }
            set { numberinvoice = value; }
        }

        private DateTime dateinvoice;
        public DateTime DateInvoice
        {
            get { return dateinvoice; }
            set { dateinvoice = value; }
        }

        private string supplier;
        public string Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }


        private SupplyProductModel selectedSupplyProduct;
        public SupplyProductModel SelectedSupplyProduct
        {
            get { return selectedSupplyProduct; }
            set { selectedSupplyProduct = value; }
        }


        private ReCommand close;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      supplyproduct.Close();
                  }));
            }
        }


        private ReCommand add_product;
        public ReCommand Add_Product
        {
            get
            {
                return add_product ??
                  (add_product = new ReCommand(obj =>
                  {
                      if (selectedSupplier == null)
                      {
                          Swapper.MessageShowText = "Не выбран поставщик. Добавление товаров невозможна.";
                          MessageShow frmMsg = new MessageShow();
                          frmMsg.ShowDialog();
                          return;
                      }
                      if (Supply_ID == 0)
                      {
                          Supply_ID = db.GetNextSupplyID();
                          Supply supply = new Supply();
                          supply.Supply_ID = Supply_ID;
                          supply.Invoice = "-";
                          supply.Supply_Data = DateTime.Now;
                          supply.Supplier_ID = selectedSupplier.Supplier_ID;
                          supply.User_ID = Swapper.CurrentUserID;
                          db.AddSupplies(supply);
                      }
                      Swapper.SupplyID = Supply_ID;
                      AddToSupply frm = new AddToSupply();
                      frm.ShowDialog();
                      SupplyProducts = new ObservableCollection<SupplyProductModel>(db.GetSupplyProduct(Supply_ID));
                      OnPropertyChanged("SupplyProducts");
                  }));
            }
        }


        private ReCommand delete_product;
        public ReCommand Delete_Product
        {
            get
            {
                return delete_product ??
                  (delete_product = new ReCommand(obj =>
                  {
                      if (SelectedSupplyProduct != null)
                      {
                          Line_of_supply los = db.GetLineOfSupply(Supply_ID, SelectedSupplyProduct.Product_ID);
                          db.RemoveLineOfSupplies(los);
                          SupplyProducts = new ObservableCollection<SupplyProductModel>(db.GetSupplyProduct(Supply_ID));
                          OnPropertyChanged("SupplyProducts");
                      }
                  }));
            }
        }


        private ReCommand applay_product;
        public ReCommand Applay_Product
        {
            get
            {
                return applay_product ??
                  (applay_product = new ReCommand(obj =>
                  {
                      for (int ii = 0; ii < SupplyProducts.Count; ii++)
                      {
                          SupplyProductModel supprmod = SupplyProducts[ii];
                          db.ApplySupplyProducts(supprmod.Product_ID, supprmod.Product_Quantity, supprmod.Product_Price);
                      }

                      supplyproduct.Close();
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
