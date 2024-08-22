using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsManagerApp.Models;
using HotelsManagerApp.Services.GuestService;

namespace HotelsManagerApp.Controllers
{
    public class ReservationController
    {
        private ReservationService _reservationService;

        public ReservationController()
        {
            _reservationService = new ReservationService();
        }

        public List<Reservation> GetAll()
        {
            return _reservationService.GetAllReservations();
        }

        public bool IsApartmentReserved(DateTime? dateTime, int id)
        {
            return _reservationService.IsApartmentReserved(dateTime, id);
        }

        public Reservation NewReservation(User loggedUser, DateTime? dateTime, Apartment appartment)
        {
            return _reservationService.NewReservation(loggedUser, dateTime, appartment);
        }

        public List<Reservation> GetAllByUserId(int id)
        {
            return _reservationService.GetAllReservationsByUserId(id);
        }


    }
}
