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
using System.Windows;

namespace HairShop.ViewModels
{
    class AddToCheckViewModel : INotifyPropertyChanged
    {
        private DBOperations db;

        private AddToCheck addtocheck;
        public AddToCheckViewModel(AddToCheck addtocheck)
        {
            this.addtocheck = addtocheck;

            db = new DBOperations();

            checkID = Swapper.CheckID;
            productID = Swapper.ProductID;
            productName = Swapper.ProductName;
            productUnitPrice = Swapper.ProductUnitPrice;
            productQuantity = Swapper.ProductQuantity;
            modeAddOrEdit = Swapper.ModeAddOrEdit;
        }

        private ReCommand close;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      addtocheck.Close();
                  }));
            }
        }

        private ReCommand add_to_check;
        public ReCommand Add_To_Check
        {
            get
            {
                return add_to_check ??
                    (add_to_check = new ReCommand(obj =>
                    {
                        //--- проверка корректности количества ---
                        int prQuantity = 0;
                        int.TryParse(productQuantity, out prQuantity);
                        if (prQuantity == 0)
                        {
                            MessageBox.Show("Недопустимое значение в поле Количество.");
                            return;
                        }
                        //--- проверка наличия товара в заказе ---
                        if (db.IsProductInCheck(checkID, productID))
                        {
                            Line_of_check loch = db.GetLineOfCheck(checkID, productID);
                            if (ModeAddOrEdit == "add")
                                prQuantity += loch.Product_Quantity;
                            db.RemoveLineOfChecks(loch);

                            loch = new Line_of_check();
                            loch.Check_ID = checkID;
                            loch.Product_ID = productID;
                            loch.Product_Quantity = prQuantity;
                            db.AddLineOfChecks(loch);
                        }
                        else
                        {
                            if (!db.IsCheckExists(checkID))
                            {
                                Check check = new Check();
                                check.Check_ID = checkID;
                                check.data_sale = DateTime.Now;
                                check.total_price = 0;
                                check.User_ID = Swapper.CurrentUserID;
                                db.AddChecks(check);
                            }
                            Line_of_check loch = new Line_of_check();
                            loch.Check_ID = checkID;
                            loch.Product_ID = productID;
                            loch.Product_Quantity = prQuantity;
                            db.AddLineOfChecks(loch);
                        }
                        addtocheck.Close();
                    }));
            }
        }

        private int checkID;
        public int CheckID
        {
            get { return checkID; }
            set { checkID = value; }
        }

        private int productID;
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private static decimal productUnitPrice;
        public static decimal ProductUnitPrice
        {
            get { return productUnitPrice; }
            set { productUnitPrice = value; }
        }

        private string productQuantity;
        public string ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; }
        }

        private string modeAddOrEdit;
        public string ModeAddOrEdit
        {
            get { return modeAddOrEdit; }
            set { modeAddOrEdit = value; }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
