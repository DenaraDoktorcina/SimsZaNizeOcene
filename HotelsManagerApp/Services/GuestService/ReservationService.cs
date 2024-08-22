using HotelsManagerApp.Models;
using HotelsManagerApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsManagerApp.Services.GuestService
{
    public class ReservationService
    {
        public ReservationRepository _reservationRepository;
        public ReservationService()
        {
            _reservationRepository = new ReservationRepository();
        }

        public List<Reservation> GetAllReservations()
        {
            return _reservationRepository.GetAll();
        }

        public bool IsApartmentReserved(DateTime? date, int appartmentId)
        {
            foreach(var r in _reservationRepository.GetAll())
            {
                if(r.ReservationDate.Value.Date == date.Value.Date && r.ReservationStatus == OwnerAnswer.ACCEPTED && r.ApartmentId == appartmentId)
                {
                    return true;
                }
            }
            return false;
        }

        public Reservation NewReservation(User loggedUser, DateTime? dateTime, Apartment appartment)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationDate = dateTime;
            reservation.ReservationStatus = OwnerAnswer.PENDING;
            reservation.ApartmentId = appartment.Id;
            reservation.GuestId = loggedUser.Id;
            reservation.ApartmentName = appartment.Name;
            return _reservationRepository.Save(reservation);
        }

        public List<Reservation> GetAllReservationsByUserId(int id)
        {
            List<Reservation> reservationsById = new List<Reservation>();
            foreach(var r in _reservationRepository.GetAll())
            {
                if(r.GuestId == id)
                {
                    reservationsById.Add(r);
                }
            }
            return reservationsById;
        }
    }
}
