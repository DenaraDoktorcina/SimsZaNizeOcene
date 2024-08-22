using HotelsManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsManagerApp.Controllers;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

namespace HotelsManagerApp.View.GuestViewModel
{
    public class MakeReservationViewModel : INotifyPropertyChanged
    {
        public User LoggedUser { get; set; }
        private ApartmentController _apartmentController {  get; set; }
        private ReservationController _reservationController { get; set; }
        public ObservableCollection<Apartment> Apartments { get; set; }
        public Apartment SelectedApartment { get; set; }

        private DateTime? _selectedDate;
        public DateTime? SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));  // Notify change
            }
        }

        public ICommand ReservationRequestCommand { get; set; }
        public MakeReservationViewModel(User Logged) 
        {
            LoggedUser = Logged;
            _apartmentController = new ApartmentController();
            _reservationController = new ReservationController();
            Apartments = new ObservableCollection<Apartment>(_apartmentController.GetAll());

            ReservationRequestCommand = new RelayCommand<object>(ReservationRequest);
        }

        public void ReservationRequest(object parameter) 
        {
            if(SelectedApartment == null)
            {
                MessageBox.Show("You have to select the apartment!");
            }else if(SelectedDate == null) 
            {
                MessageBox.Show("Select the date");
            }else if(_reservationController.IsApartmentReserved(SelectedDate, SelectedApartment.Id))
            {
                MessageBox.Show("Apartment is already reserved");
            }else
            {
                Reservation newReservation = _reservationController.NewReservation(LoggedUser, SelectedDate, SelectedApartment);
                MessageBox.Show($"Novi Id: {newReservation.Id}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
