using HotelsManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsManagerApp.Serializer;

namespace HotelsManagerApp.Repositories
{
    public class ReservationRepository
    {
        private const string FilePath = "../../../Resources/Data/reservations.csv";
        private readonly Serializer<Reservation> _serializer;
        public List<Reservation> reservations { get; set; }

        public ReservationRepository()
        {
            _serializer = new Serializer<Reservation>();
            reservations = _serializer.FromCSV(FilePath);
        }

        public List<Reservation> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public Reservation Save(Reservation reservation)
        {
            reservation.Id = NextId();
            reservations = _serializer.FromCSV(FilePath);
            reservations.Add(reservation);
            _serializer.ToCSV(FilePath, reservations);
            return reservation;
        }

        public int NextId()
        {
            reservations = _serializer.FromCSV(FilePath);
            if(reservations.Count<1)
            {
                return 1;
            }
            return reservations.Max(r => r.Id) + 1;
        }

        public Reservation Delete(Reservation SelectedReservation, User LoggedUser)
        {
            reservations = _serializer.FromCSV(FilePath);
            Reservation foundReservation = reservations.Find(c => c.ApartmentId == SelectedReservation.Id);
            reservations.Remove(foundReservation);
            _serializer.ToCSV(FilePath, reservations);
            return foundReservation;
        }

        public void Update(Reservation updatedReservation)
        {
            reservations = _serializer.FromCSV(FilePath);
            Reservation current = reservations.Find(c => c.Id == updatedReservation.Id);
            int index = reservations.IndexOf(current);
            reservations.Remove(current);
            reservations.Insert(index, updatedReservation);
            _serializer.ToCSV(FilePath, reservations);
            
        }
    }
}
