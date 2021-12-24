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
    class AddProductSupplyViewModel : INotifyPropertyChanged
    {
        private DBOperations db;

        private AddProductSupply addproductsupply;
        public AddProductSupplyViewModel(AddProductSupply addproductsupply)
        {
            this.addproductsupply = addproductsupply;

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
