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
            return _hotelRepository.GetAll().Where(hotel => hotel.NewHotel == HotelSuggestion.ACCEPTED).ToList();
        }

        public List<Hotel> GetSearch(string searchTerm, string selectedFilter, User logged)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return GetAllByOwnerJmbg(logged);
            }

            switch (selectedFilter)
            {
                case "ID":
                    return SearchById(searchTerm, logged);
                case "Name":
                    return SearchByName(searchTerm, logged);
                case "Construction Year":
                    return SearchByYear(searchTerm, logged);
                case "Number of Stars":
                    return SearchByStars(searchTerm, logged);
                default:
                    return GetAllHotels();
            }
        }

        private List<Hotel> SearchById(string searchTerm, User logged)
        {
            if (int.TryParse(searchTerm, out int hotelId))
            {
                return GetAllByOwnerJmbg(logged)
                    .Where(h => h.Id == hotelId)
                    .ToList();
            }
            throw new ArgumentException("Invalid ID format.");
        }

        private List<Hotel> SearchByName(string searchTerm, User logged)
        {
            return GetAllByOwnerJmbg(logged)
                .Where(h => h.Name.ToLower().Contains(searchTerm.ToLower()))
                .ToList();
        }

        private List<Hotel> SearchByYear(string searchTerm, User logged)
        {
            if (int.TryParse(searchTerm, out int constructionYear))
            {
                return GetAllByOwnerJmbg(logged)
                    .Where(h => h.YearOfConstruction == constructionYear)
                    .ToList();
            }
            throw new ArgumentException("Invalid Construction Year format.");
        }

        private List<Hotel> SearchByStars(string searchTerm, User logged)
        {
            if (int.TryParse(searchTerm, out int stars))
            {
                return GetAllByOwnerJmbg(logged)
                    .Where(h => h.NumberOfStars == stars)
                    .ToList();
            }
            throw new ArgumentException("Invalid number of Stars format.");
        }

        public List<Hotel> GetSuggestedNewHotels(User forOwner)
        {
            List<Hotel> newHotels = new();
            foreach(var h in _hotelRepository.GetAll())
            {
                if(h.OwnerJmbg == forOwner.Jmbg && h.NewHotel == HotelSuggestion.PENDING)
                {
                    newHotels.Add(h);
                }
            }
            return newHotels;
        }

        public void Update(Hotel SelectedHotel)
        {
            _hotelRepository.Update(SelectedHotel);
        }

        public List<Hotel> GetAllByOwnerJmbg(User logged)
        {
            List<Hotel> ownersHotels = new();
            foreach(var h in GetAllHotels())
            {
                if(h.OwnerJmbg == logged.Jmbg)
                {
                    ownersHotels.Add(h);
                }
            }
            return ownersHotels;
        }

        public int Add(Hotel newHotel)
        {
            return _hotelRepository.Save(newHotel);
        }
    }
}
