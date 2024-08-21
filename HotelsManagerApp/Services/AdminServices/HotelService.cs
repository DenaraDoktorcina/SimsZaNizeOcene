using HotelsManagerApp.Controllers;
using HotelsManagerApp.Models;
using HotelsManagerApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelsManagerApp.Services.AdminServices
{
    public class HotelService
    {
        public HotelRepository _hotelRepository;
        public HotelService() 
        {
            _hotelRepository = new HotelRepository();
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAll();
        }

        public List<Hotel> GetSearch(string searchTerm, string selectedFilter)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return GetAllHotels();
            }

            switch (selectedFilter)
            {
                case "ID":
                    return SearchById(searchTerm);
                case "Name":
                    return SearchByName(searchTerm);
                case "Construction Year":
                    return SearchByYear(searchTerm);
                case "Number of Stars":
                    return SearchByStars(searchTerm);
                default:
                    return GetAllHotels();
            }
        }

        private List<Hotel> SearchById(string searchTerm)
        {
            if (int.TryParse(searchTerm, out int hotelId))
            {
                return _hotelRepository.GetAll()
                    .Where(h => h.Id == hotelId)
                    .ToList();
            }
            throw new ArgumentException("Invalid ID format.");
        }

        private List<Hotel> SearchByName(string searchTerm)
        {
            return _hotelRepository.GetAll()
                .Where(h => h.Name.ToLower().Contains(searchTerm.ToLower()))
                .ToList();
        }

        private List<Hotel> SearchByYear(string searchTerm)
        {
            if (int.TryParse(searchTerm, out int constructionYear))
            {
                return _hotelRepository.GetAll()
                    .Where(h => h.YearOfConstruction == constructionYear)
                    .ToList();
            }
            throw new ArgumentException("Invalid Construction Year format.");
        }

        private List<Hotel> SearchByStars(string searchTerm)
        {
            if (int.TryParse(searchTerm, out int stars))
            {
                return _hotelRepository.GetAll()
                    .Where(h => h.NumberOfStars == stars)
                    .ToList();
            }
            throw new ArgumentException("Invalid number of Stars format.");
        }
    }
}
