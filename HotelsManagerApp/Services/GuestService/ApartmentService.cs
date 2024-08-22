using HotelsManagerApp.Models;
using HotelsManagerApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsManagerApp.Services.GuestService
{
    public class ApartmentService
    {
        public ApartmentRepository _apartmentRepository;
        public ApartmentService() 
        {
            _apartmentRepository = new ApartmentRepository();
        }

        public List<Apartment> GetAllApartments()
        {
            return _apartmentRepository.GetAll();
        }
    }
}
