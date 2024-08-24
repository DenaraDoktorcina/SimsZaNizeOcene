using HotelsManagerApp.Models;
using HotelsManagerApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsManagerApp.Repositories
{
    public class ApartmentRepository
    {
        private const string FilePath = "../../../Resources/Data/apartments.csv";
        private readonly Serializer<Apartment> _serializer;
        public List<Apartment> apartments { get; set; }

        public ApartmentRepository()
        {
            _serializer = new Serializer<Apartment>();
            apartments = _serializer.FromCSV(FilePath);
        }

        public List<Apartment> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public int Save(Apartment newApartment)
        {
            newApartment.Id = NextId();
            apartments = _serializer.FromCSV(FilePath);
            apartments.Add(newApartment);
            _serializer.ToCSV(FilePath, apartments);
            return newApartment.Id;
        }

        public int NextId()
        {
            apartments = _serializer.FromCSV(FilePath);
            if(apartments.Count < 1)
            {
                return 1;
            }
            return apartments.Max(x => x.Id) +1;
        }
    }
}
