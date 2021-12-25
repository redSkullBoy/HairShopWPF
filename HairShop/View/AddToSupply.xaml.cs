using HairShop.Services;
using HairShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HairShop.View
{
    /// <summary>
    /// Логика взаимодействия для AddToSupply.xaml
    /// </summary>
    public partial class AddToSupply : Window
    {
        public AddToSupply()
        {
            InitializeComponent();
            DataContext = new AddToSupplyViewModel(this);
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Swapper.SupplyID = ((AddToSupplyViewModel)DataContext).Supply_ID;
            Swapper.ProductID = ((AddToSupplyViewModel)DataContext).SelectedProduct.Product_ID;
            Swapper.ProductName = ((AddToSupplyViewModel)DataContext).SelectedProduct.Product_Name;
            AddProductSupply frm = new AddProductSupply();
            frm.ShowDialog();
            this.Close();
        }
    }
}
