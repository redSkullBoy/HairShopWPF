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
using HairShop.Services;
using HairShop.ViewModels;

namespace HairShop.View
{
    /// <summary>
    /// Логика взаимодействия для MakeCheck.xaml
    /// </summary>
    public partial class MakeCheck : Window
    {
        public MakeCheck()
        {
            InitializeComponent();
            DataContext = new MakeCheckViewModel(this);
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Swapper.CheckID = ((MakeCheckViewModel)DataContext).CheckID;
            Swapper.ProductID = ((MakeCheckViewModel)DataContext).SelectedProduct.Product_ID;
            Swapper.ProductName = ((MakeCheckViewModel)DataContext).SelectedProduct.Product_Name;
            Swapper.ProductUnitPrice = ((MakeCheckViewModel)DataContext).SelectedProduct.unit_price;
            Swapper.ProductQuantity = "";
            Swapper.ModeAddOrEdit = "add";
            AddToCheck frm = new AddToCheck();
            frm.ShowDialog();
            ((MakeCheckViewModel)DataContext).RefreshCheckProducts();
        }
        private void SummaReceived_TextChanged(object sender, EventArgs e)
        {
            ((MakeCheckViewModel)DataContext).RefreshCheckProducts();
        }

        private void SummaReceived_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Return) return;
            ((MakeCheckViewModel)DataContext).RefreshCheckProducts();
        }

        private void TextBox_KeyEnterUpdate(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox tBox = (TextBox)sender;
                DependencyProperty prop = TextBox.TextProperty;

                BindingExpression binding = BindingOperations.GetBindingExpression(tBox, prop);
                if (binding != null) { binding.UpdateSource(); }
            }
        }

    }
}
