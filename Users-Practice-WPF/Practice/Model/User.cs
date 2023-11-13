using Practice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Model
{
    public class User :NotificationService
    {
        private int id1;
        private string? name1;
        private string? username1;
        private string? email1;
        private Address? address1;
        private string? website1;
        private Company? company1;

        public int id { get => id1; set { id1 = value; OnPropertyChanged(); } }
        public string? name { get => name1; set { name1 = value; OnPropertyChanged(); } }
        public string? username { get => username1; set { username1 = value;OnPropertyChanged(); } }
        public string? email { get => email1; set { email1 = value; OnPropertyChanged(); } }
        public Address? address { get => address1; set { address1 = value; OnPropertyChanged(); } }
        public string? website { get => website1; set { website1 = value;OnPropertyChanged(); } }
        public Company? company { get => company1; set { company1 = value; OnPropertyChanged(); } }


        public User()
        {
            address = new();
            company = new();
        }
        public override string ToString()
        {
            return $"{name}";
        }
    }

}
