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
using System.Windows;

namespace HairShop.ViewModels
{
    class DiscountEditViewModel : INotifyPropertyChanged
    {
        private DBOperations db;

        private DiscountEdit discountedit;
        public DiscountEditViewModel(DiscountEdit discountedit)
        {
            this.discountedit = discountedit;

            db = new DBOperations();

            ProductTypes = new ObservableCollection<ProductTypeModel>(db.GetProductTypes());

            if (Swapper.DiscountID == 0)
            {
                Discount_DateBeg = DateTime.Now;
                Discount_DateEnd = DateTime.Now;
            }
            else
            {
                discountExists = db.GetDiscount(Swapper.DiscountID);
                Discount_Name = discountExists.Discount_Name;
                Discount_Percent = discountExists.Discount_amount;
                Discount_DateBeg = discountExists.D_Start;
                Discount_DateEnd = discountExists.D_End;
                if (discountExists.Product_Type_ID != null)
                {
                    for (int ii = 0; ii < ProductTypes.Count; ii++)
                    {
                        if (ProductTypes[ii].Product_Type_ID == discountExists.Product_Type_ID)
                        {
                            SelectedProductType = ProductTypes[ii];
                            break;
                        }
                    }
                }
            }

        }

        public ObservableCollection<ProductTypeModel> ProductTypes { get; set; }

        private ProductTypeModel selectedProductType;
        public ProductTypeModel SelectedProductType
        {
            get { return selectedProductType; }
            set { selectedProductType = value; }
        }

        Discount discountExists;

        private string discount_name;
        public string Discount_Name
        {
            get { return discount_name; }
            set { discount_name = value; }
        }

        private int discount_percent;
        public int Discount_Percent
        {
            get { return discount_percent; }
            set { discount_percent = value; }
        }

        private DateTime discount_datebeg;
        public DateTime Discount_DateBeg
        {
            get { return discount_datebeg; }
            set { discount_datebeg = value; }
        }

        private DateTime discount_dateend;
        public DateTime Discount_DateEnd
        {
            get { return discount_dateend; }
            set { discount_dateend = value; }
        }


        private ReCommand close;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      discountedit.Close();
                  }));
            }
        }


        private ReCommand save_discount;
        public ReCommand Save_Discount
        {
            get
            {
                return save_discount ??
                  (save_discount = new ReCommand(obj =>
                  {
                      //проверка корректности заполненных данных
                      if (Discount_Name == null || Discount_Name.Trim() == "")
                      {
                          MessageBox.Show("Не заполнено поле <Название акции>.");
                          return;
                      }
                      if (Discount_Percent == 0)
                      {
                          MessageBox.Show("Не заполнено поле <Процент акции>.");
                          return;
                      }
                      if (Discount_DateBeg == null)
                      {
                          MessageBox.Show("Не заполнено поле <Дата начала акции>.");
                          return;
                      }
                      if (Discount_DateEnd == null)
                      {
                          MessageBox.Show("Не заполнено поле <Дата начала акции>.");
                          return;
                      }

                      if (Swapper.DiscountID > 0)
                          db.RemoveDiscounts(discountExists);

                      Discount discount = new Discount();
                      discount.Discount_ID = db.GetNextDiscountID();
                      discount.Discount_Name = Discount_Name;
                      discount.Discount_amount = Discount_Percent;
                      discount.D_Start = Discount_DateBeg;
                      discount.D_End = Discount_DateEnd;
                      if (SelectedProductType != null)
                          discount.Product_Type_ID = SelectedProductType.Product_Type_ID;
                      db.AddDiscounts(discount);

                      discountedit.Close();
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
