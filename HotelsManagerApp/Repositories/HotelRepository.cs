using HotelsManagerApp.Models;
using HotelsManagerApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsManagerApp.Repositories
{
    public class HotelRepository
    {
        private const string FilePath = "../../../Resources/Data/hotels.csv";
        private readonly Serializer<Hotel> _serializer;
        private List<Hotel> hotels;

        public HotelRepository()
        {
            _serializer = new Serializer<Hotel>();
            hotels = _serializer.FromCSV(FilePath);
        }

        public List<Hotel> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public void Update(Hotel SelectedHotel)
        {
            hotels = _serializer.FromCSV(FilePath);
            Hotel current = hotels.Find(c => c.Id == SelectedHotel.Id);
            int index = hotels.IndexOf(current);
            hotels.Remove(current);
            hotels.Insert(index, SelectedHotel);
            _serializer.ToCSV(FilePath, hotels);
        }

    }
}
