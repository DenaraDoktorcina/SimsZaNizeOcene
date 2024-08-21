using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsManagerApp.Serializer;

namespace HotelsManagerApp.Models
{
    public class Apartment : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; } //jedinstveno
        public string Description { get; set; }
        public int RoomsNumber { get; set; }
        public int MaxGuests { get; set; }
        
        public Apartment() { }

        public Apartment(int id, string name, string description, int roomsNumber, int maxGuests)
        {
            Id = id;
            Name = name;
            Description = description;
            RoomsNumber = roomsNumber;
            MaxGuests = maxGuests;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Name = values[1];
            Description = values[2];
            RoomsNumber = int.Parse(values[3]);
            MaxGuests = int.Parse(values[4]);
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Name.ToString(),
                Description.ToString(),
                RoomsNumber.ToString(),
                MaxGuests.ToString(),
            };
            return csvValues;
        }
    }
}
