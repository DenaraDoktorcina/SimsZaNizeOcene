﻿using HotelsManagerApp.Controllers;
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

namespace HotelsManagerApp.View.GuestViewModel
{
    public class GuestAllReservatonsViewModel : INotifyPropertyChanged
    {
        public User LoggedUser { get; set; }
        private ObservableCollection<Reservation> _allReservations; 

        public ObservableCollection<Reservation> Reservations { get; set; }
        private ReservationController _reservationController { get; set; }

        public string _selectedStatus;
        public string SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                if (_selectedStatus != value)
                {
                    _selectedStatus = value;
                    OnPropertyChanged(nameof(SelectedStatus));
                    HandleStatusChange(value);
                }
            }
        }

        public Reservation _selectedReservation;
        public Reservation SelectedReservation
        {
            get { return _selectedReservation; }
            set
            {
                if(_selectedReservation != value)
                {
                    _selectedReservation = value;
                    OnPropertyChanged(nameof(SelectedReservation));
                }
            }
        }

        public ICommand CancelReservationCommand { get; set; }
        public GuestAllReservatonsViewModel(User loggedUser) 
        {
            LoggedUser = loggedUser;
            _reservationController = new ReservationController();

            _allReservations = new ObservableCollection<Reservation>(_reservationController.GetAllByUserId(loggedUser.Id));
            Reservations = new ObservableCollection<Reservation>(_reservationController.GetAllByUserId(loggedUser.Id));
            CancelReservationCommand = new RelayCommand<object>(CancelReservation);
        }

        public void CancelReservation(object parameter)
        {
            if(SelectedReservation == null || SelectedReservation.ReservationStatus == OwnerAnswer.REJECTED)
            {
                MessageBox.Show("You need to select a reservation!");
            }else
            {
                _reservationController.CancelReservation(SelectedReservation, LoggedUser);
                MessageBox.Show("You CANCELED your reservation!");
                Reservations.Remove(SelectedReservation);
                OnPropertyChanged(nameof(Reservations));
            }
        }

        private void HandleStatusChange(string comboBoxResult)
        {
            const string prefix = "System.Windows.Controls.ComboBoxItem: ";
            string newStatus = comboBoxResult.Substring(prefix.Length).Trim();
            if (string.IsNullOrEmpty(newStatus) || newStatus == "ALL")
            {
                Reservations = new ObservableCollection<Reservation>(_allReservations);
            }
            else
            {
                var filteredReservations = _allReservations
                    .Where(r => r.ReservationStatus.ToString() == newStatus)
                    .ToList();

                Reservations = new ObservableCollection<Reservation>(filteredReservations);
            }

            OnPropertyChanged(nameof(Reservations));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
