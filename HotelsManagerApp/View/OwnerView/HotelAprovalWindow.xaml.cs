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
using HotelsManagerApp.Models;
using HotelsManagerApp.View.OwnerViewModel;

namespace HotelsManagerApp.View.OwnerView
{
    /// <summary>
    /// Interaction logic for HotelAprovalWindow.xaml
    /// </summary>
    public partial class HotelAprovalWindow : Window
    {
        public HotelAprovalWindow(User logged)
        {
            InitializeComponent();
            DataContext = new HotelAprovalViewModel(logged);
        }
    }
}
