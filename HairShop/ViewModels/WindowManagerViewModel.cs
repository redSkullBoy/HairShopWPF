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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
