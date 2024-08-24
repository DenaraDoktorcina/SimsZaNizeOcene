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
using HotelsManagerApp.View.OwnerView;

namespace HotelsManagerApp.View.OwnerViewModel
{
    public class OwnerMainWindowViewModel : INotifyPropertyChanged
    {
        public User LoggedUser { get; set; }
        private HotelController _hotelController { get; set; }
        public ObservableCollection<Hotel> Hotels { get; set; }
        public Hotel SelectedHotel {  get; set; }
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
        public ICommand AllReservationsCommand { get; set; }
        public ICommand ManageReservationsCommand { get; set; }
        public ICommand HotelAprovalCommand {  get; set; }
        public ICommand AddApartmentCommand {  get; set; }
        public OwnerMainWindowViewModel(User logged) 
        {
            LoggedUser = logged;
            _hotelController = new HotelController();
            Hotels = new ObservableCollection<Hotel>(_hotelController.GetAllByOwnerJmbg(logged));

            SearchCommand = new RelayCommand<object>(SearchHotel);
            AllReservationsCommand = new RelayCommand<object>(AllReservations);
            ManageReservationsCommand = new RelayCommand<object>(ManageReservations);
            HotelAprovalCommand = new RelayCommand<object>(HotelAproval);
            AddApartmentCommand = new RelayCommand<object>(AddApartment);

            SelectedFilter = FilterOptions[0];
        }

        public void AddApartment(object parameter)
        {
            if(SelectedHotel == null)
            {
                MessageBox.Show("You need to select a Hotel!");
                return;
            }
            NewApartmentWindow naw = new NewApartmentWindow(SelectedHotel);
            naw.Show();
        }

        public void HotelAproval(object parameter)
        {
            HotelAprovalWindow haw = new HotelAprovalWindow(LoggedUser);
            haw.Show();
        }

        public void ManageReservations(object parameter)
        {
            if(SelectedHotel == null)
            {
                MessageBox.Show("You have to select a hotel!");
            }else
            {
                ManageReservationRequestsWindow mrrw = new ManageReservationRequestsWindow(SelectedHotel, LoggedUser);
                mrrw.Show();
            }
        }

        public void AllReservations(object parameter)
        {
            AllReservations all = new AllReservations(LoggedUser);
            all.Show();
        }

        public void ResetHotelsList()
        {
            Hotels = new ObservableCollection<Hotel>(_hotelController.GetAllByOwnerJmbg(LoggedUser));
            OnPropertyChanged(nameof(Hotels));
        }

        public void SearchHotel(object parameter)
        {
            try
            {
                Hotels = new ObservableCollection<Hotel>(_hotelController.GetBySearchTerm(SearchTerm, SelectedFilter, LoggedUser));
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
