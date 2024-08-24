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

namespace HotelsManagerApp.View.OwnerViewModel
{
    public class ManageReservationRequestsViewModel : INotifyPropertyChanged
    {
        public User LoggedUser { get; set; }
        public Hotel SelectedHotel {  get; set; }
        public Reservation SelectedReservation {  get; set; }
        public string RejectionComment {  get; set; }
        public ObservableCollection<Reservation> ReservationsForSelectedHotel { get; set; }
        public ReservationController _reservationController {  get; set; }
        public ICommand RejectReservationCommand { get; set; }
        public ICommand AcceptReservationCommand { get; set; }
        public ManageReservationRequestsViewModel(Hotel selectedHotel, User Logged) 
        {
            LoggedUser = Logged;
            SelectedHotel = selectedHotel;

            _reservationController = new ReservationController();

            ReservationsForSelectedHotel = new ObservableCollection<Reservation>(_reservationController.GetReservationsForSelectedHotel(SelectedHotel));

            RejectReservationCommand = new RelayCommand<object>(RejectReservation);
            AcceptReservationCommand = new RelayCommand<object>(AcceptedReservation);
            RejectionComment = "";
        }

        public void RejectReservation(object parameter)
        {
            if(SelectedReservation == null)
            {
                MessageBox.Show("You have to select a reservation!");
            }else if(RejectionComment == "")
            {
                MessageBox.Show("You have to input a comment!");
            }else
            {
                _reservationController.RejectedReservation(SelectedReservation, RejectionComment);
                ReservationsForSelectedHotel = new ObservableCollection<Reservation>(_reservationController.GetReservationsForSelectedHotel(SelectedHotel));
                OnPropertyChanged(nameof(ReservationsForSelectedHotel));
            }
        }

        public void AcceptedReservation(object parameter)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
