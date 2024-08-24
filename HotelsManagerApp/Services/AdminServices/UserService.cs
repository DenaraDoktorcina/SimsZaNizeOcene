using HotelsManagerApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelsManagerApp.Models;

namespace HotelsManagerApp.Services.AdminServices
{
    public class UserService
    {
        public UserRepository _userRepository;
        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User? GetUserByEmail(string email)
        {
            foreach (var user in GetAllUsers())
            {
                if (user.Email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public void Add(User newowner)
        {
            _userRepository.Save(newowner);
        }
    }
}
