using HairShop.Models;
using System;
using System.Collections.Generic;
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
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
