using HotelsManagerApp.Controllers;
using HotelsManagerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelsManagerApp.View.AdminViewModel
{
    public class RegisterNewOwnerViewModel : INotifyPropertyChanged
    {
        public UserController _userController {  get; set; }
        public User LoggedUser { get; set; }

        private string _jmbg;
        public string Jmbg
        {
            get { return _jmbg; }
            set
            {
                if (_jmbg != value)
                {
                    _jmbg = value;
                    OnPropertyChanged(nameof(Jmbg));
                }
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

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

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                }
            }
        }

        private string _telephoneNumber;
        public string TelephoneNumber
        {
            get { return _telephoneNumber; }
            set
            {
                if (_telephoneNumber != value)
                {
                    _telephoneNumber = value;
                    OnPropertyChanged(nameof(TelephoneNumber));
                }
            }
        }

        public ICommand CancelCommand { get; set; }
        public ICommand SubmitCommand { get; set; }

        public RegisterNewOwnerViewModel(User logged) 
        {
            LoggedUser = logged;
            _userController = new UserController();

            CancelCommand = new RelayCommand<object>(Cancel);
            SubmitCommand = new RelayCommand<object>(Submit);

            Jmbg = "";
            Email = "";
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
            if (_userController.DoesJmbgAlreadyExists(Jmbg) || Jmbg=="")
            {
                MessageBox.Show("Inupt different jmbg!");   
            }else if(_userController.DoesEmailAlreadyExists(Email) || Email=="")
            {
                MessageBox.Show("Inupt different email!");
            }else
            {
                User newOwner = new();
                newOwner.Jmbg = Jmbg;
                newOwner.Name = Name;
                newOwner.Surname = Surname;
                newOwner.Email = Email;
                newOwner.Password = Password;
                newOwner.Phone = TelephoneNumber;
                newOwner.UserType = TypeOfUser.OWNER;
                _userController.Add(newOwner);
                if (parameter is System.Windows.Window window)
                {
                    window.Close();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
