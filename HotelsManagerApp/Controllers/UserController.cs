using HotelsManagerApp.Services.AdminServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsManagerApp.Models;

namespace HotelsManagerApp.Controllers
{
    public class UserController
    {
        private UserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }

        public List<User> GetAll()
        {
            return _userService.GetAllUsers();
        }

        public User? GetUserByEmail(string email)
        {
            return _userService.GetUserByEmail(email);
        }

        public void Add(User newowner)
        {
            _userService.Add(newowner);
        }
    }
}
