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
using HotelsManagerApp.View.GuestViewModel;
using HotelsManagerApp.Models;

namespace HotelsManagerApp.View.GuestView
{
    /// <summary>
    /// Interaction logic for GuestMainWindow.xaml
    /// </summary>
    public partial class GuestMainWindow : Window
    {
        public GuestMainWindow(User LoggedUser)
        {
            InitializeComponent();
            DataContext = new GuestMainWindowViewModel(LoggedUser);
        }
    }
}
