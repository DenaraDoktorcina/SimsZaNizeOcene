using HotelsManagerApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsManagerApp.Models
{
    public enum OwnerAnswer { ACCEPTED=1, REJECTED, PENDING }

    public class Reservation : ISerializable
    {
        public int Id { get; set; } //id same rezervacije
        public int ApartmentId { get; set; } //id apartmana koji je rezervisan
        public int GuestId { get; set; } //id gosta koji je napravio rezervaciju
        public DateTime? ReservationDate { get; set; }
        public OwnerAnswer ReservationStatus { get; set; }
        public string RejectionComment {  get; set; }
        public string ApartmentName {  get; set; }

        public Reservation() { }

        public Reservation(int id, int apartmentId, DateTime? reservationDate, OwnerAnswer reservationStatus)
        {
            Id = id;
            ApartmentId = apartmentId;
            ReservationDate = reservationDate;
            ReservationStatus = reservationStatus;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            ApartmentId = int.Parse(values[1]);
            ReservationDate = DateTime.ParseExact(values[2], "yyyy-MM-dd HH:mm:ss", null);
            ReservationStatus = (OwnerAnswer)Enum.Parse(typeof(OwnerAnswer), values[3]);
            GuestId = int.Parse(values[4]);
            RejectionComment = values[5];
            ApartmentName = values[6];
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                ApartmentId.ToString(),
                ReservationDate.HasValue ? ReservationDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty,
                ReservationStatus.ToString(),
                GuestId.ToString(),
                RejectionComment,
                ApartmentName
            };
            return csvValues;
        }
    }
}
