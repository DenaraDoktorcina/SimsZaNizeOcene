using HotelsManagerApp.Controllers;
using HotelsManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using HotelsManagerApp.View.GuestView;

namespace HotelsManagerApp.View.GuestViewModel
{
    public class GuestMainWindowViewModel : INotifyPropertyChanged
    {
        public User LoggedUser { get; set; }
        private HotelController _hotelController { get; set; }
        public ObservableCollection<Hotel> Hotels { get; set; }
        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                OnPropertyChanged(nameof(SearchTerm));

                if (string.IsNullOrWhiteSpace(_searchTerm))
                {
                    ResetHotelsList();
                }
            }
        }

        private string _selectedFilter;
        public string SelectedFilter
        {
            get { return _selectedFilter; }
            set
            {
                _selectedFilter = value;
                OnPropertyChanged(nameof(SelectedFilter));

                SearchTerm = string.Empty;
                ResetHotelsList();
            }
        }

        public List<string> FilterOptions { get; } = new List<string>
        {
            "ID",
            "Name",
            "Construction Year",
            "Apartments",
            "Number of Stars"
        };

        public ICommand SearchCommand { get; set; }
        public ICommand MakeReservationCommand {  get; set; }
        public ICommand SeeYourReservationsCommand {  get; set; }
        public ICommand CancelReservationCommand {  get; set; }
        public GuestMainWindowViewModel(User logged) 
        {
            LoggedUser = logged;
            _hotelController = new HotelController();
            Hotels = new ObservableCollection<Hotel>(_hotelController.GetAll());
            SearchCommand = new RelayCommand<object>(SearchHotel);
            MakeReservationCommand = new RelayCommand<object>(MakeReservation);
            SeeYourReservationsCommand = new RelayCommand<object>(SeeYourReservations);
            CancelReservationCommand = new RelayCommand<object>(CancelReservation);

            SelectedFilter = FilterOptions[0];
        }

        public void ResetHotelsList()
        {
            Hotels = new ObservableCollection<Hotel>(_hotelController.GetAll());
            OnPropertyChanged(nameof(Hotels));
        }

        public void CancelReservation(object parameter)
        {

        }

        public void SeeYourReservations(object parameter)
        {
            GuestAllReservations allReservations = new GuestAllReservations(LoggedUser);
            allReservations.Show();
        }

        public void MakeReservation(object parameter)
        {
            MakeReservationWindow reservationWindow = new MakeReservationWindow(LoggedUser);
            reservationWindow.Show();
        }

        public void SearchHotel(object parameter)
        {
            try
            {
                Hotels = new ObservableCollection<Hotel>(_hotelController.GetBySearchTerm(SearchTerm, SelectedFilter));
                OnPropertyChanged(nameof(Hotels));
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
