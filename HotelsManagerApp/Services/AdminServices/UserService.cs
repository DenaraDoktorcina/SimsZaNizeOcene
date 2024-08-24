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

        public bool DoesJmbgAlreadyExists(string jmbg)
        {
            foreach (var user in GetAllUsers())
            {
                if(user.Jmbg == jmbg)
                {
                    return true;
                }
            }
            return false;
        }
        public bool DoesEmailAlreadyExists(string email)
        {
            foreach (var user in GetAllUsers())
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public void Update(User updatedUser)
        {
            _userRepository.Update(updatedUser);
        }

        public List<User> GetAllOwners()
        {
            return _userRepository.GetAllOwners();
        }
    }
}
