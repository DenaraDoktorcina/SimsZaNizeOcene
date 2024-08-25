using HotelsManagerApp.Models;
using HotelsManagerApp.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsManagerApp.Controllers
{
    public class HotelController
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

        public List<Hotel> GetBySearchTerm(string SearchTerm, string SelectedFilter, User logged)
        {
            return _hotelService.GetSearch(SearchTerm, SelectedFilter, logged);
        }

        public List<Hotel> GetSuggestedNewHotels(User forOwner)
        {
            return _hotelService.GetSuggestedNewHotels(forOwner);
        }

        public void Update(Hotel selectedHotel)
        {
            _hotelService.Update(selectedHotel);
        }

        public List<Hotel> GetAllByOwnerJmbg(User logged)
        {
            return _hotelService.GetAllByOwnerJmbg(logged);
        }

        public int Add(Hotel newHotel)
        {
            return _hotelService.Add(newHotel);
        }

        public List<Hotel> GetByApartmentSearch(string apartmentSearchTerm, string searchBy, User logged)
        {
            return _hotelService.GetByApartmentSearch(apartmentSearchTerm, searchBy, logged);
        }
    }
}
