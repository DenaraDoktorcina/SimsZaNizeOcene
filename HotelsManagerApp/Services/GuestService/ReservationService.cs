using HotelsManagerApp.Models;
using HotelsManagerApp.Repositories;
using HotelsManagerApp.Services.AdminServices;
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
        public HotelService _hotelService;
        public ApartmentService _apartmentService;
        public ReservationService()
        {
            _reservationRepository = new ReservationRepository();

            _hotelService = new HotelService();
            _apartmentService = new ApartmentService();
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

        public Reservation CancelReservation(Reservation SelectedReservation, User Loggeduser)
        {
            return _reservationRepository.Delete(SelectedReservation, Loggeduser);
        }

        public List<Reservation> GetReservationsByOwnerId(User LoggedOwner)
        {
            List<Reservation> reservationsForOwnersHotels = new List<Reservation>();
            foreach(var h in _hotelService.GetAllHotels())
            {
                if(h.OwnerJmbg == LoggedOwner.Jmbg)
                {
                    foreach(var a in h.ApartmentsIds)
                    {
                        foreach(var r in _reservationRepository.GetAll())
                        {
                            if(r.ApartmentId == a)
                            {
                                reservationsForOwnersHotels.Add(r);
                            }
                        }
                    }
                }
            }

            return reservationsForOwnersHotels;
        }

        public List<Reservation> GetReservationsForSelectedHotel(Hotel SelectedHotel)
        {
            List<Reservation> reservations = new List<Reservation>();
            foreach(var a in SelectedHotel.ApartmentsIds)
            {
                foreach(var r in _reservationRepository.GetAll())
                {
                    if(a == r.ApartmentId && r.ReservationStatus == OwnerAnswer.PENDING)
                    {
                        reservations.Add(r);
                    }
                }
            }
            return reservations;
        }

        public void RejectedReservation(Reservation selectedReservation, string rejectionComment)
        {
            selectedReservation.RejectionComment = rejectionComment;
            selectedReservation.ReservationStatus = OwnerAnswer.REJECTED;
            _reservationRepository.Update(selectedReservation);
        }
    }
}
