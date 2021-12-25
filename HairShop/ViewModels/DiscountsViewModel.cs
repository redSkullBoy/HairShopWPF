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
    class DiscountsViewModel : INotifyPropertyChanged
    {
        private DBOperations db;

        private Discounts discounts;
        public DiscountsViewModel(Discounts discounts)
        {
            this.discounts = discounts;

            db = new DBOperations();

            TableDiscounts = new ObservableCollection<DiscountModel>(db.GetDiscounts());

        }

        public ObservableCollection<DiscountModel> TableDiscounts { get; set; }

        private DiscountModel selecteddiscount;
        public DiscountModel SelectedDiscount
        {
            get { return selecteddiscount; }
            set { selecteddiscount = value; }
        }

        private ReCommand close;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      discounts.Close();
                  }));
            }
        }


        private ReCommand create_discount;
        public ReCommand Create_Discount
        {
            get
            {
                return create_discount ??
                  (create_discount = new ReCommand(obj =>
                  {
                      Swapper.DiscountID = 0;
                      DiscountEdit frm = new DiscountEdit();
                      frm.ShowDialog();
                      TableDiscounts = new ObservableCollection<DiscountModel>(db.GetDiscounts());
                      OnPropertyChanged("TableDiscounts");
                  }));
            }
        }


        private ReCommand edit_discount;
        public ReCommand Edit_Discount
        {
            get
            {
                return edit_discount ??
                  (edit_discount = new ReCommand(obj =>
                  {
                      if (selecteddiscount != null)
                      {
                          Swapper.DiscountID = selecteddiscount.Discount_ID;
                          DiscountEdit frm = new DiscountEdit();
                          frm.ShowDialog();
                          TableDiscounts = new ObservableCollection<DiscountModel>(db.GetDiscounts());
                          OnPropertyChanged("TableDiscounts");
                      }
                  }));
            }
        }


        private ReCommand delete_discount;
        public ReCommand Delete_Discount
        {
            get
            {
                return delete_discount ??
                  (delete_discount = new ReCommand(obj =>
                  {
                      if (selecteddiscount != null)
                      {
                          Discount discount = db.GetDiscount(selecteddiscount.Discount_ID);
                          db.RemoveDiscounts(discount);

                          TableDiscounts = new ObservableCollection<DiscountModel>(db.GetDiscounts());
                          OnPropertyChanged("TableDiscounts");
                      }
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
