using Practice.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Model
{
    public class Company:NotificationService
    {
        private string? name1;
        private string? bs1;

        public string? name { get => name1; set { name1 = value;OnPropertyChanged(); } }
        public string? bs { get => bs1; set { bs1 = value; OnPropertyChanged(); } }
    }
}
