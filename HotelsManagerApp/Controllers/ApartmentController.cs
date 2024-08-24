using HotelsManagerApp.Services.GuestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsManagerApp.Models;

namespace HotelsManagerApp.Controllers
{
    public class ApartmentController
    {
        private ApartmentService _apartmentService;

        public ApartmentController() 
        {
            _apartmentService = new ApartmentService();
        }

        public List<Apartment> GetAll()
        {
            return _apartmentService.GetAllApartments();
        }

        public int Add(Apartment newAppartment)
        {
            return _apartmentService.Add(newAppartment);
        }
    }
}
