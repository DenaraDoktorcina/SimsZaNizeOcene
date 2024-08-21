using HotelsManagerApp.Controllers;
using HotelsManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsManagerApp.View.AdminViewModel
{
    public class AdminMainWindowViewModel
    {
        public User LoggedUser { get; set; }
        private HotelController _hotelController {  get; set; }
        public ObservableCollection<Hotel> Hotels { get; set; }
        public AdminMainWindowViewModel(User Logged) 
        {
            LoggedUser = Logged;
            _hotelController = new HotelController();
            Hotels = new ObservableCollection<Hotel>(_hotelController.GetAll());
        }
    }
}
