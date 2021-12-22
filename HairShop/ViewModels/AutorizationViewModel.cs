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

namespace HairShop.ViewModels
{
    class AutorizationViewModel : INotifyPropertyChanged
    {
        private ShopContext HairShop;

        private Authorization authorization;
        public AutorizationViewModel(Authorization authorization)
        {
            this.authorization = authorization;
            HairShop = new ShopContext();
        }

        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private ReCommand entrance; //вход
        public ReCommand Entrance
        {
            get
            {
                return entrance ??
                  (entrance = new ReCommand(obj =>
                  {
                      var passwordBox = obj as PasswordBox;
                      if (passwordBox == null || passwordBox.Password == "")
                          return;
                      var _password = passwordBox.Password;

                      User user = HairShop.Users.Where(i => i.Login == login).SingleOrDefault();
                      if (user != null && user.Password.ToString() == _password)
                      {
                          int userRole = user.Role;
                          if (userRole == 1) //--- менеджер
                          {
                              WindowManager winManager = new WindowManager();
                              authorization.Close();
                              winManager.Show();
                          }
                          else //--- продавец
                          {
                              //WindowSalesman winSalesman = new WindowSalesman();
                              //authorization.Close();
                              //winSalesman.Show();
                              MakeCheck makeCheck = new MakeCheck();
                              authorization.Close();
                              makeCheck.Show();
                          }
                      }
                      else MessageBox.Show("Логин или пароль введены неверно!");
                  }));
            }
        }


        private ReCommand close;
        public ReCommand Close_Win
        {
            get
            {
                return close ??
                  (close = new ReCommand(obj =>
                  {
                      authorization.Close();
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
