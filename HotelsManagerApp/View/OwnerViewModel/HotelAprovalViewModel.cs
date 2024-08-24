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
    public class HotelAprovalViewModel : INotifyPropertyChanged
    {
        public User LoggedUser { get; set; }
        public HotelController _hotelController { get; set; }
        public ObservableCollection<Hotel> NewHotels { get; set; }
        public Hotel SelectedHotel { get; set; }
        public ICommand RejectCommand {  get; set; }
        public ICommand AcceptCommand { get; set; }

        public HotelAprovalViewModel(User logged) 
        {
            LoggedUser = logged;
            _hotelController = new HotelController();

            NewHotels = new ObservableCollection<Hotel>(_hotelController.GetSuggestedNewHotels(LoggedUser));

            RejectCommand = new RelayCommand<object>(RejectNewHotel);
            AcceptCommand = new RelayCommand<object>(AcceptNewHotel);
        }

        public void RejectNewHotel(object parameter)
        {
            if(SelectedHotel == null)
            {
                MessageBox.Show("You have to select a hotel!");
            }else
            {
                SelectedHotel.NewHotel = HotelSuggestion.REJECTED;
                _hotelController.Update(SelectedHotel);
                NewHotels = new ObservableCollection<Hotel>(_hotelController.GetSuggestedNewHotels(LoggedUser));
                OnPropertyChanged(nameof(NewHotels));
            }
        }
        public void AcceptNewHotel(object parameter)
        {
            SelectedHotel.NewHotel = HotelSuggestion.ACCEPTED;
            _hotelController.Update(SelectedHotel);
            NewHotels = new ObservableCollection<Hotel>(_hotelController.GetSuggestedNewHotels(LoggedUser));
            OnPropertyChanged(nameof(NewHotels));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
