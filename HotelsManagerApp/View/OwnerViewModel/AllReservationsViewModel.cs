using HotelsManagerApp.Controllers;
using HotelsManagerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsManagerApp.View.OwnerViewModel
{
    public class AllReservationsViewModel : INotifyPropertyChanged
    {
        public ReservationController _reservationController {  get; set; }
        public User LoggedUser { get; set; }
        private ObservableCollection<Reservation> _allReservations;
        public ObservableCollection<Reservation> ReservationsForOwnersHotels { get; set; }

        private string _selectedStatus;
        public string SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                if (_selectedStatus != value)
                {
                    _selectedStatus = value;
                    OnPropertyChanged(nameof(SelectedStatus));
                    FilterReservationsByStatus();
                }
            }
        }
        public AllReservationsViewModel(User logged) 
        {
            LoggedUser = logged;
            _reservationController = new ReservationController();

            _allReservations = new ObservableCollection<Reservation>(_reservationController.GetReservationsByOwnerId(LoggedUser));

            ReservationsForOwnersHotels = new ObservableCollection<Reservation>(_allReservations);
            _selectedStatus = "ALL";
        }

        private void FilterReservationsByStatus()
        {
            const string prefix = "System.Windows.Controls.ComboBoxItem: ";
            string newSelectedStatusString = SelectedStatus.Substring(prefix.Length).Trim();
            if (string.IsNullOrEmpty(newSelectedStatusString) || newSelectedStatusString == "ALL")
            {
                ReservationsForOwnersHotels = new ObservableCollection<Reservation>(_allReservations);
            }
            else
            {
                List<Reservation>? filteredReservations = _allReservations
                    .Where(r => r.ReservationStatus.ToString() == newSelectedStatusString)
                    .ToList();

                ReservationsForOwnersHotels = new ObservableCollection<Reservation>(filteredReservations);
            }

            OnPropertyChanged(nameof(ReservationsForOwnersHotels));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
