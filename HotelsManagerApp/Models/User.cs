using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HotelsManagerApp.Serializer;

namespace HotelsManagerApp.Models
{
    public enum TypeOfUser { ADMINISTRATOR = 0, GUEST = 1, OWNER = 2 }
    public enum IsUserBlocked { ACTIVE =1, BLOCKED}
    public class User : ISerializable
    {

        public int Id { get; set; }
        public string Jmbg { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public TypeOfUser UserType { get; set; }

        public IsUserBlocked UserStatus { get; set; }

        public User() { }

        public User(int id, string jmbg, string email, string password, string name, string surname, string phone, TypeOfUser userType)
        {
            Id = id;
            Jmbg = jmbg;
            Email = email;
            Password = password;
            Name = name;
            Surname = surname;
            Phone = phone;
            UserType = userType;
        }


        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Jmbg = values[1];
            Email = values[2];
            Password = values[3];
            Name = values[4];
            Surname = values[5];
            Phone = values[6];
            UserType = (TypeOfUser)Enum.Parse(typeof(TypeOfUser), values[7]);
            UserStatus = (IsUserBlocked)Enum.Parse(typeof(IsUserBlocked), values[8]);
        }
        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Jmbg.ToString(),
                Email.ToString(),
                Password.ToString(),
                Name.ToString(),
                Surname.ToString(),
                Phone.ToString(),
                UserType.ToString(),
                UserStatus.ToString(),
            };
            return csvValues;
        }
    }
}
