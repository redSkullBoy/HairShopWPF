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
            AddToCheck frm = new AddToCheck();
            frm.ShowDialog();
        }
    }
}
