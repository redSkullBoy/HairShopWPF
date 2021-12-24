using HairShop.Models;
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
    class WindowManagerViewModel : INotifyPropertyChanged
    {
        private DBOperations db;

        private WindowManager windowmanager;
        public WindowManagerViewModel(WindowManager windowmanager)
        {
            this.windowmanager = windowmanager;

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
                      windowmanager.Close();
                  }));
            }
        }

        private ReCommand storage_balance;
        public ReCommand Storage_Balance
        {
            get
            {
                return storage_balance ??
                  (storage_balance = new ReCommand(obj =>
                  {
                      windowmanager.Hide();
                      StorageBalance frm = new StorageBalance();
                      frm.ShowDialog();
                      windowmanager.Show();
                  }));
            }
        }

        private ReCommand supply_product;
        public ReCommand Supply_Product
        {
            get
            {
                return supply_product ??
                  (supply_product = new ReCommand(obj =>
                  {
                      windowmanager.Hide();
                      HairShop.View.SupplyProduct frm = new HairShop.View.SupplyProduct();
                      frm.ShowDialog();
                      windowmanager.Show();
                  }));
            }
        }

        private ReCommand edit_discounts;
        public ReCommand Edit_Discounts
        {
            get
            {
                return edit_discounts ??
                  (edit_discounts = new ReCommand(obj =>
                  {
                      windowmanager.Hide();
                      Discounts frm = new Discounts();
                      frm.ShowDialog();
                      windowmanager.Show();
                  }));
            }
        }


        private ReCommand report_best;
        public ReCommand Report_BestProducts
        {
            get
            {
                return report_best ??
                  (report_best = new ReCommand(obj =>
                  {
                      ReportBestProducts frm = new ReportBestProducts();
                      frm.ShowDialog();
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
