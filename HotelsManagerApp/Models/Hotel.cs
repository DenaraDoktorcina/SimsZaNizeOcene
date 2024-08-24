using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsManagerApp.Serializer;

namespace HotelsManagerApp.Models
{
    public enum HotelSuggestion { ACCEPTED = 1, REJECTED, PENDING}
    public class Hotel : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfConstruction { get; set; }
        public List<Apartment> Apartmants { get; set; }
        public List<int> ApartmentsIds { get; set; }
        public int NumberOfStars { get; set; }
        public string OwnerJmbg { get; set; }
        public HotelSuggestion NewHotel {  get; set; }
        public Hotel() { }
        public Hotel(int id, string name, int yearOfConstruction, List<Apartment> apartmants, int numberOfStars, string ownerJmbg)
        {
            Id = id;
            Name = name;
            YearOfConstruction = yearOfConstruction;
            Apartmants = apartmants;
            NumberOfStars = numberOfStars;
            OwnerJmbg = ownerJmbg;
        }

        public Hotel(string name, int yearOfConstruction, int numberOfStars, string ownerJmbg)
        {
            Name = name;
            YearOfConstruction = yearOfConstruction;
            NumberOfStars = numberOfStars;
            OwnerJmbg = ownerJmbg;
            ApartmentsIds = new List<int> { 0 };
            NewHotel = HotelSuggestion.PENDING;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Name = values[1];
            YearOfConstruction = int.Parse(values[2]);
            NumberOfStars = int.Parse(values[3]);
            OwnerJmbg = values[4];
            ApartmentsIds = values[5].Split(',').Select(int.Parse).ToList();
            NewHotel = (HotelSuggestion)Enum.Parse(typeof(HotelSuggestion), values[6]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Name.ToString(),
                YearOfConstruction.ToString(),
                NumberOfStars.ToString(),
                OwnerJmbg.ToString(),
                string.Join(",", ApartmentsIds),
                NewHotel.ToString()
            };
            return csvValues;
        }
    }
}
