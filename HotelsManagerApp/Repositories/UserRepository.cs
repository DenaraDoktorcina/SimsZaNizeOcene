using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents.Serialization;
using HotelsManagerApp.Models;
using HotelsManagerApp.Serializer;

namespace HotelsManagerApp.Repositories
{
    public class UserRepository
    {
        private const string FilePath = "../../../Resources/Data/users.csv";
        private readonly Serializer<User> _serializer;
        private List<User> users;

        public UserRepository()
        {
            _serializer = new Serializer<User>();
            users = _serializer.FromCSV(FilePath);
        }

        public List<User> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }
    }
}
