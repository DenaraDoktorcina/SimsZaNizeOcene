using HotelsManagerApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelsManagerApp.Models;
using System.Windows;

namespace HotelsManagerApp.View.AdminViewModel
{
    public class NewHotelViewModel : INotifyPropertyChanged
    {
        private string _name;
        private int _constructionYear;
        private int _starsNumber;
        private User _selectedOwnerJmbg;
        private List<User> _ownersJmbgList;
        public UserController _userController;
        public HotelController _hotelController;
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

        public int ConstructionYear
        {
            get { return _constructionYear; }
            set
            {
                if (_constructionYear != value)
                {
                    _constructionYear = value;
                    OnPropertyChanged(nameof(ConstructionYear));
                }
            }
        }

        public int StarsNumber
        {
            get { return _starsNumber; }
            set
            {
                if (_starsNumber != value)
                {
                    _starsNumber = value;
                    OnPropertyChanged(nameof(StarsNumber));
                }
            }
        }

        public User SelectedOwnerJmbg
        {
            get { return _selectedOwnerJmbg; }
            set
            {
                if (_selectedOwnerJmbg != value)
                {
                    _selectedOwnerJmbg = value;
                    OnPropertyChanged(nameof(SelectedOwnerJmbg));
                }
            }
        }

        public List<User> OwnersJmbgList
        {
            get { return _ownersJmbgList; }
            set
            {
                if (_ownersJmbgList != value)
                {
                    _ownersJmbgList = value;
                    OnPropertyChanged(nameof(OwnersJmbgList));
                }
            }
        }
        public ICommand CancelCommand { get; set; }
        public ICommand SubmitCommand { get; set; }

        public NewHotelViewModel() 
        {
            _userController = new UserController();
            _hotelController = new HotelController();

            OwnersJmbgList = _userController.GetAllOwners();

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
            Hotel newHotel = new Hotel(Name, ConstructionYear, StarsNumber, SelectedOwnerJmbg.Jmbg);
            MessageBox.Show($"{_hotelController.Add(newHotel)}");

            if (parameter is System.Windows.Window window)
            {
                window.Close();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
