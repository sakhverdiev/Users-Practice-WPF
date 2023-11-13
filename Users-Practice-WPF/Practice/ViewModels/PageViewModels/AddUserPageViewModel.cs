using Practice.Commands;
using Practice.Database;
using Practice.Model;
using Practice.Service;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Practice.ViewModels.PageViewModels;

public class AddUserPageViewModel:NotificationService
{
    private User? user;

    public User? newUser { get => user; set { user = value; OnPropertyChanged(); } }

    public ICommand AddBtnClicked{ get; set; }
    public ICommand BackBtnClicked{ get; set; }

    public AddUserPageViewModel()
    {
        UsersCollection.LoadDatabase();
        this.newUser = new User();
        AddBtnClicked = new RelayCommand(AddBtn, CanAddBtn);
        BackBtnClicked = new RelayCommand(BackBtn);
    }


    public void BackBtn(object? parameter)
    {
        var pg = parameter as Page;

        pg.NavigationService.GoBack();

    }

    public void AddBtn(object? parameter)
    {
        if (newUser.name != null && newUser.username != null && newUser.email != null && newUser.website != null && newUser.address.street != null && newUser.address.city != null && newUser.company.name != null && newUser.company.bs != null)
        {
            UsersCollection.Users.Add(newUser);
            newUser = new();
            UsersCollection.UptadeDatabase();
        }
        else {
            MessageBox.Show("Something is null!!");
        }
    }

    public bool CanAddBtn(object? parameter)
    {
        if (newUser.name != null && newUser.username != null && newUser.email != null && newUser.website != null && newUser.address.street != null && newUser.address.city != null && newUser.company.name != null && newUser.company.bs != null)
        {
            return true;
        }
        return false;
    }










}
