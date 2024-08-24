using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelsManagerApp.Controllers;
using HotelsManagerApp.Models;

namespace HotelsManagerApp.View.OwnerViewModel
{
    public class NewApartmentViewModel : INotifyPropertyChanged
    {
        public ApartmentController _apartmentController {  get; set; }
        public HotelController _hotelController { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private int _roomsNumber;
        public int RoomsNumber
        {
            get { return _roomsNumber; }
            set
            {
                if (_roomsNumber != value)
                {
                    _roomsNumber = value;
                    OnPropertyChanged(nameof(RoomsNumber));
                }
            }
        }

        private int _maxGuestsNumber;
        public int MaxGuestsNumber
        {
            get { return _maxGuestsNumber; }
            set
            {
                if (_maxGuestsNumber != value)
                {
                    _maxGuestsNumber = value;
                    OnPropertyChanged(nameof(MaxGuestsNumber));
                }
            }
        }

        public Hotel SelectedHotel {  get; set; }
        public ICommand CancelCommand {  get; set; }
        public ICommand SubmitCommand { get; set; }

        public NewApartmentViewModel(Hotel selectedHotel)
        {
            _apartmentController = new ApartmentController();
            _hotelController = new HotelController();

            SelectedHotel = selectedHotel;

            CancelCommand = new RelayCommand<object>(Cancel);
            SubmitCommand = new RelayCommand<object>(Submit);
        }

        public void Cancel(object parameter)
        {
            if (parameter is System.Windows.Window window)
            {
                window.Close();
            }
        }

        public void Submit(object parameter)
        {
            Apartment newApartment = new();
            newApartment.RoomsNumber = RoomsNumber;
            newApartment.MaxGuests = MaxGuestsNumber;
            newApartment.Name = Name;
            newApartment.Description = Description;
            SelectedHotel.ApartmentsIds.Add(_apartmentController.Add(newApartment));
            _hotelController.Update(SelectedHotel);
            if (parameter is System.Windows.Window window)
            {
                window.Close();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
