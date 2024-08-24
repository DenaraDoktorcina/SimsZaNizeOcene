using HotelsManagerApp.Controllers;
using HotelsManagerApp.Models;
using HotelsManagerApp.View.AdminView;
using HotelsManagerApp.View.GuestView;
using HotelsManagerApp.View.OwnerView;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HotelsManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        
        public int loginAttemptsNumber {  get; set; }
        public UserController _userController {  get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;      
            
            _userController = new UserController();
            loginAttemptsNumber = 0;
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            User? LoggedUser = _userController.GetUserByEmail(Email);
            if(LoggedUser == null)
            {
                MessageBox.Show("Wrong email");
                loginAttemptsNumber++;
                if (loginAttemptsNumber == 3)
                {
                    this.Close();
                }
            }
            else
            {
                if(txtPassword.Password != LoggedUser.Password)
                {
                    MessageBox.Show("Wrong password");
                    loginAttemptsNumber++;
                    if (loginAttemptsNumber == 3)
                    {
                        this.Close();
                    }
                }
                else if(LoggedUser.UserStatus == IsUserBlocked.ACTIVE)
                {
                    switch (LoggedUser.UserType)
                    {
                        case TypeOfUser.ADMINISTRATOR:
                            AdminMainWindow adminWindow = new AdminMainWindow(LoggedUser);
                            adminWindow.Show();
                            break;

                        case TypeOfUser.GUEST:
                            GuestMainWindow guestWindow = new GuestMainWindow(LoggedUser);
                            guestWindow.Show();
                            break;

                        case TypeOfUser.OWNER:
                            OwnerMainWindow ownerWindow = new OwnerMainWindow(LoggedUser);
                            ownerWindow.Show();
                            break;

                    }
                }
                else
                {
                    MessageBox.Show("Your account has been BLOCKED by an admin!");
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}