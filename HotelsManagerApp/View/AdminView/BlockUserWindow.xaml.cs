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
using HotelsManagerApp.View.AdminViewModel;
namespace HotelsManagerApp.View.AdminView
{
    /// <summary>
    /// Interaction logic for BlockUserWindow.xaml
    /// </summary>
    public partial class BlockUserWindow : Window
    {
        public BlockUserWindow()
        {
            InitializeComponent();
            DataContext = new BlockUserViewModel();
        }
    }
}
