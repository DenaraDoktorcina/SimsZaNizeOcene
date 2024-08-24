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

        public void Save(User newUser)
        {
            newUser.UserStatus = IsUserBlocked.ACTIVE;
            newUser.Id = NextId();
            users = _serializer.FromCSV(FilePath);
            users.Add(newUser);
            _serializer.ToCSV(FilePath, users);
        }
        public int NextId()
        {
            users = _serializer.FromCSV(FilePath);
            if (users.Count < 1)
            {
                return 1;
            }
            return users.Max(x => x.Id) + 1;
        }

        public void Update(User updatedUser)
        {
            users = _serializer.FromCSV(FilePath);
            User current = users.Find(c => c.Id == updatedUser.Id);
            int index = users.IndexOf(current);
            users.Remove(current);
            users.Insert(index, updatedUser);
            _serializer.ToCSV(FilePath, users);
        }
    }
}
