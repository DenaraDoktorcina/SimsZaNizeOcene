using HotelsManagerApp.Models;
using HotelsManagerApp.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsManagerApp.Controllers
{
    class HotelController
    {
        private HotelService _hotelService;

        public HotelController()
        {
            _hotelService = new HotelService();
        }

        public List<Hotel> GetAll()
        {
            return _hotelService.GetAllHotels();
        }

        public List<Hotel> GetBySearchTerm(string SearchTerm, string SelectedFilter)
        {
            return _hotelService.GetSearch(SearchTerm, SelectedFilter);
        }
    }
}
