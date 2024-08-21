using HotelsManagerApp.Controllers;
using HotelsManagerApp.Models;
using HotelsManagerApp.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelsManagerApp.View.AdminViewModel
{
    public class AdminMainWindowViewModel : INotifyPropertyChanged
    {
        public User LoggedUser { get; set; }
        private HotelController _hotelController {  get; set; }
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
        public AdminMainWindowViewModel(User Logged) 
        {
            LoggedUser = Logged;
            _hotelController = new HotelController();
            Hotels = new ObservableCollection<Hotel>(_hotelController.GetAll());
            SearchCommand = new RelayCommand<object>(SearchHotel);

            SelectedFilter = FilterOptions[0];
        }

        public void ResetHotelsList()
        {
            Hotels = new ObservableCollection<Hotel>(_hotelController.GetAll());
            OnPropertyChanged(nameof(Hotels));
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
