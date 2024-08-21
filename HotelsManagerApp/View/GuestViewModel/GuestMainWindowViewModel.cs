using HotelsManagerApp.Controllers;
using HotelsManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsManagerApp.View.GuestViewModel
{
    public class GuestMainWindowViewModel
    {
        public User LoggedUser { get; set; }
        private HotelController _hotelController { get; set; }
        public ObservableCollection<Hotel> Hotels { get; set; }
        public GuestMainWindowViewModel(User logged) 
        {
            LoggedUser = logged;
            _hotelController = new HotelController();
            Hotels = new ObservableCollection<Hotel>(_hotelController.GetAll());
        }
    }
}
