using HotelsManagerApp.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsManagerApp.Models;
using System.ComponentModel;

namespace HotelsManagerApp.View.AdminViewModel
{
    public class AllUsersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> AllUsers { get; set; }
        private ObservableCollection<User> _filteredUsers;
        public ObservableCollection<User> FilteredUsers
        {
            get { return _filteredUsers; }
            set
            {
                if (_filteredUsers != value)
                {
                    _filteredUsers = value;
                    OnPropertyChanged(nameof(FilteredUsers));
                }
            }
        }
        public UserController _userController { get; set; }
        public string[] UserTypes { get; set; } = { "All", "ADMINISTRATOR", "GUEST", "OWNER" };
        private string _selectedUserType;
        public string SelectedUserType
        {
            get { return _selectedUserType; }
            set
            {
                if (_selectedUserType != value)
                {
                    _selectedUserType = value;
                    OnPropertyChanged(nameof(SelectedUserType));
                    FilterUsers();
                }
            }
        }
        public AllUsersViewModel() 
        {
            _userController = new UserController();
            AllUsers = new ObservableCollection<User>(_userController.GetAll());
            FilteredUsers = new ObservableCollection<User>(AllUsers);

            SelectedUserType = "All";
        }

        private void FilterUsers()
        {
            if (SelectedUserType == "All")
            {
                FilteredUsers = new ObservableCollection<User>(AllUsers);
                OnPropertyChanged(nameof(FilteredUsers));
            }
            else
            {
                FilteredUsers = new ObservableCollection<User>(
                    AllUsers.Where(u => u.UserType.ToString() == SelectedUserType)
                );
                OnPropertyChanged(nameof(FilteredUsers));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
