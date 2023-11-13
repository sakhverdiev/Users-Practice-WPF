using Practice.Commands;
using Practice.Database;
using Practice.Model;
using Practice.Service;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Practice.ViewModels.WindowViewModels;

public class EditUserViewModel:NotificationService
{
    private User reference1;
    private User temp1;

    public User reference { get => reference1; set { reference1 = value; OnPropertyChanged(); } }

    public User temp { get => temp1; set { temp1 = value;OnPropertyChanged(); } }

    public ICommand SaveCommand{ get; set; }

    public EditUserViewModel(User car)
    {
        reference = car;
        temp = new User();
        temp.name = car.name;   
        temp.email = car.email;
        temp.username = car.username;
        temp.address = car.address; 
        temp.id = car.id;
        temp.company = car.company;
        temp.website = car.website;
        SaveCommand = new RelayCommand(Save);

    }

    public void Save(object? parameter)
    {
        reference.name = temp.name;
        reference.email = temp.email;
        reference.username = temp.username;
        reference.address = temp.address;
        reference.id = temp.id;
        reference.company = temp.company;
        reference.website = temp.website;
        UsersCollection.UptadeDatabase();
    }
}
