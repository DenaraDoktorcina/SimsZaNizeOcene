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

namespace HotelsManagerApp.View.AdminViewModel
{

    public class BlockUserViewModel : INotifyPropertyChanged
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

        public User SelectedUser {  get; set; }

        public ICommand BlockUserCommand {  get; set; }
        public BlockUserViewModel() 
        {
            _userController = new UserController();
            AllUsers = new ObservableCollection<User>(_userController.GetAll());
            FilteredUsers = new ObservableCollection<User>(AllUsers);

            BlockUserCommand = new RelayCommand<object>(BlockUser);

            SelectedUserType = "All";
        }

        public void BlockUser(object parameter)
        {
            if(SelectedUser == null)
            {
                MessageBox.Show("You need to select a user!");
            }
            else
            {
                if (SelectedUser.UserStatus == IsUserBlocked.BLOCKED)
                {
                    SelectedUser.UserStatus = IsUserBlocked.ACTIVE;
                }
                else
                {
                    SelectedUser.UserStatus = IsUserBlocked.BLOCKED;
                }
                _userController.Update(SelectedUser);
                AllUsers = new ObservableCollection<User>(_userController.GetAll());
                FilteredUsers = new ObservableCollection<User>(AllUsers);
                OnPropertyChanged(nameof(FilteredUsers));
                OnPropertyChanged(nameof(AllUsers));
            }
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
