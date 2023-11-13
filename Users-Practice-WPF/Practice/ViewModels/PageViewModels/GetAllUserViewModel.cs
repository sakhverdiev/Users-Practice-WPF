using Practice.Commands;
using Practice.Database;
using Practice.Model;
using Practice.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Practice.ViewModels.PageViewModels
{
    internal class GetAllUserViewModel:NotificationService
    {
        private ObservableCollection<User> users;

        public ObservableCollection<User> Users { get => users; set { users = value; OnPropertyChanged(); } }

        public ICommand BackBtnClicked { get; set; }


        public GetAllUserViewModel()
        {
            UsersCollection.LoadDatabase();
            Users = UsersCollection.Users;
            BackBtnClicked = new RelayCommand(BackBtn);

        }


        public void BackBtn(object? parameter)
        {
            var pg = parameter as Page;

            pg.NavigationService.GoBack();

        }
    }
}
