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
    class DiscountEditViewModel : INotifyPropertyChanged
    {
        private DBOperations db;

        private DiscountEdit discountedit;
        public DiscountEditViewModel(DiscountEdit discountedit)
        {
            this.discountedit = discountedit;

            db = new DBOperations();
          
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
