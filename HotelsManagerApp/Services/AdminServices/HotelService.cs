using HotelsManagerApp.Models;
using HotelsManagerApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsManagerApp.Services.AdminServices
{
    public class HotelService
    {
        public HotelRepository _hotelRepository;
        public HotelService() 
        {
            _hotelRepository = new HotelRepository();
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAll();
        }
    }
}
