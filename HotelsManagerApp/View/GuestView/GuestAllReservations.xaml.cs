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
using HotelsManagerApp.View.GuestViewModel;

namespace HotelsManagerApp.View.GuestView
{
    /// <summary>
    /// Interaction logic for GuestAllReservations.xaml
    /// </summary>
    public partial class GuestAllReservations : Window
    {
        public GuestAllReservations(User loggedUser)
        {
            InitializeComponent();
            DataContext = new GuestAllReservatonsViewModel(loggedUser);
        }
    }
}
