using HotelsManagerApp.Controllers;
using HotelsManagerApp.Models;
using HotelsManagerApp.Repositories;
using HotelsManagerApp.Services.GuestService;
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
        public ApartmentService _apartmentService;
        public HotelService() 
        {
            _hotelRepository = new HotelRepository();
            _apartmentService = new ApartmentService();
        }

        public List<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAll().Where(hotel => hotel.NewHotel == HotelSuggestion.ACCEPTED).ToList();
        }

        public List<Hotel> GetSearch(string searchTerm, string selectedFilter, User logged)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.Equals(searchTerm, "") || string.Equals(searchTerm, ""))
            {
                if(logged.UserType == TypeOfUser.OWNER)
                {
                    return GetAllByOwnerJmbg(logged);
                }
                return GetAllHotels();
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
                if(logged.UserType != TypeOfUser.OWNER)
                {
                    return GetAllHotels().Where(h => h.Id == hotelId).ToList();
                }
                return GetAllByOwnerJmbg(logged)
                    .Where(h => h.Id == hotelId)
                    .ToList();
            }
            throw new ArgumentException("Invalid ID format.");
        }

        private List<Hotel> SearchByName(string searchTerm, User logged)
        {
            if (logged.UserType != TypeOfUser.OWNER)
            {
                return GetAllHotels().Where(h => h.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }
            return GetAllByOwnerJmbg(logged)
                .Where(h => h.Name.ToLower().Contains(searchTerm.ToLower()))
                .ToList();
        }

        private List<Hotel> SearchByYear(string searchTerm, User logged)
        {
            if (int.TryParse(searchTerm, out int constructionYear))
            {
                if (logged.UserType != TypeOfUser.OWNER)
                {
                    return GetAllHotels().Where(h => h.YearOfConstruction == constructionYear).ToList();
                }
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
                if (logged.UserType != TypeOfUser.OWNER)
                {
                    return GetAllHotels().Where(h => h.NumberOfStars == stars).ToList();
                }
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

        public List<Hotel> GetByApartmentSearch(string apartmentSearchTerm, string searchBy, User logged)
        {
            if(apartmentSearchTerm.Equals("") || apartmentSearchTerm.Equals(null))
            {
                return GetAllByOwnerJmbg(logged);
            }
            else if(searchBy.Equals("Number of rooms"))
            {
                return SearchByRoomsNumber(apartmentSearchTerm);

            }else if(searchBy.Equals("Number of guests"))
            {
                string[] splitTerms = apartmentSearchTerm.Split('&');
                return SearchByGuestsNumber(apartmentSearchTerm);
            }else
            {
                return SearchByRoomsNumberAndOrGuestsNumber(apartmentSearchTerm);
            }
        }

        public List<Hotel> SearchByRoomsNumber(string SearchByRoomsNumber)
        {
            List<Hotel> hotels = new();
            foreach(var h in GetAllHotels())
            {
                foreach(var a in h.ApartmentsIds)
                {
                    foreach(var aprtmnt in _apartmentService.GetAllApartments())
                    {
                        if(a == aprtmnt.Id && aprtmnt.RoomsNumber == int.Parse(SearchByRoomsNumber))
                        {
                            hotels.Add(h);
                        }
                    }
                }
            }
            return hotels;
        }
        public List<Hotel> SearchByGuestsNumber(string SearchByGuestsNumber)
        {
            List<Hotel> hotels = new();
            foreach (var h in GetAllHotels())
            {
                foreach (var a in h.ApartmentsIds)
                {
                    foreach (var aprtmnt in _apartmentService.GetAllApartments())
                    {
                        if (a == aprtmnt.Id && aprtmnt.MaxGuests == int.Parse(SearchByGuestsNumber))
                        {
                            hotels.Add(h);
                        }
                    }
                }
            }
            return hotels;
        }
        public List<Hotel> SearchByRoomsNumberAndOrGuestsNumber(string searchTerm)
        {
            List<Hotel> hotels = new();

            if (searchTerm.Contains('|'))
            {
                string[] splitTerms = searchTerm.Split('|');

                if (!string.IsNullOrEmpty(splitTerms[0]))
                {
                    List<Hotel> hotelsByRooms = SearchByRoomsNumber(splitTerms[0]);
                    hotels.AddRange(hotelsByRooms);
                }

                if (splitTerms.Length > 1 && !string.IsNullOrEmpty(splitTerms[1]))
                {
                    List<Hotel> hotelsByGuests = SearchByGuestsNumber(splitTerms[1]);
                    hotels.AddRange(hotelsByGuests);
                }
            }else
            {

                string[] splitTerms = searchTerm.Split('&');

                List<Hotel> hotelsByRooms = new();
                if (!string.IsNullOrEmpty(splitTerms[0]))
                {
                    hotelsByRooms = SearchByRoomsNumber(splitTerms[0]);
                }

                List<Hotel> hotelsByGuests = new();
                if (splitTerms.Length > 1 && !string.IsNullOrEmpty(splitTerms[1]))
                {
                    hotelsByGuests = SearchByGuestsNumber(splitTerms[1]);
                }

                List<Hotel> matchingHotels = new();
                if (hotelsByRooms.Count > 0 && hotelsByGuests.Count > 0)
                {
                    // Iterate through hotelsByRooms and check if any hotel matches in hotelsByGuests
                    foreach (var hotelInRooms in hotelsByRooms)
                    {
                        // If the current hotel from hotelsByRooms is also in hotelsByGuests, add it to the matchingHotels list
                        if (hotelsByGuests.Any(hotelInGuests => hotelInGuests.Id == hotelInRooms.Id))
                        {
                            matchingHotels.Add(hotelInRooms);
                        }
                    }
                }
                else
                {
                    hotels = new List<Hotel>();
                    return hotels;
                }

                // The final result is stored in matchingHotels
                hotels = matchingHotels;
            }

            return hotels;
        }
    }
}
