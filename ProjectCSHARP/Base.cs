using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCSHARP
{
    abstract class Base
    {
        static int id = 0;
        public Base(string name, string surname, string city, string phoneNumber, int age,string username,string password)
        {
            ID = id++;
            Name = name;
            Surname = surname;
            City = city;
            PhoneNumber = phoneNumber;
            Age = age;
            Username = username;
            Password = password;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int  Age { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        public override string ToString()
        {
            return $"ID : {ID}\nName : {Name}\nSurname : {Surname}\nCity : {City}\nPhone Nunber : {PhoneNumber}\nAge : {Age}\nUsername : {Username}";
        }
    }
}
