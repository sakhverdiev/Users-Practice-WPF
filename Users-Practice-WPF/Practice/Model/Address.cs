using Practice.Service;

namespace Practice.Model
{
    public class Address:NotificationService
    {
        private string? street1;
        private string? city1;

        public string? street { get => street1; set { street1 = value; OnPropertyChanged(); } }
        public string? city { get => city1; set { city1 = value;OnPropertyChanged(); } }
    }

}
