﻿using Practice.Commands;
using Practice.Database;
using Practice.Model;
using Practice.Service;
using Practice.ViewModels.WindowViewModels;
using Practice.Views.Pages;
using Practice.Views.Windows;
using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Printing;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Practice.ViewModels.PageViewModels;

public class MainPageViewModel: NotificationService
{
    private ObservableCollection<User> users;

    public ObservableCollection<User> Users { get => users; set { users = value;  OnPropertyChanged(); } }


    public ICommand AddCommand{ get; set; }
    public ICommand RemoveCommand{ get; set; }
    public ICommand EditCommand{ get; set; }
    public ICommand GetAllCommand{ get; set; }
    public MainPageViewModel()
    {
        UsersCollection.LoadDatabase();
        Users = UsersCollection.Users!;
        AddCommand = new RelayCommand(Add);
        RemoveCommand = new RelayCommand(Remove, CanRemove);
        EditCommand = new RelayCommand(EditUser, CanEditUser);
        GetAllCommand = new RelayCommand(GetAll);
    }

    public void GetAll(object? parameter)
    {
        var page = parameter as Page;
        if (page !=null)
        {
            page.NavigationService.Navigate(new GetAllPage());
        }


    }
    public void Add(object? parameter)
    {
        var pg = parameter as Page;
        if (pg != null)
        {
            var page = new AddUserPage();
            page.DataContext = new AddUserPageViewModel();
            pg.NavigationService.Navigate(page);
        }
    }

    public void EditUser(object? parameter)
    {
        var select = parameter as int?;
        if (select != null && select != -1)
        {
            var editCarView = new EditUserWindow();
            editCarView.DataContext = new EditUserViewModel(Users[Convert.ToInt32(select)]);
            editCarView.ShowDialog();
        }




    }
    public bool CanEditUser(object? parameter)
    {
        var select = parameter as int?;
        if (select != null && select != -1)
        {
            return true;
        }
        return false;
    }

    public void  Remove(object? parameter)
    {
        int index = Convert.ToInt32(parameter);

        if (index != null && index != -1)
        {
            Users.RemoveAt(index);
            UsersCollection.Users.RemoveAt(index);
            UsersCollection.UptadeDatabase();

        }
        
    }
    public bool CanRemove(object? parameter)
    {
        int index = Convert.ToInt32(parameter);

        if (index != null && index != -1)
        {
            return true;
        }
        return false;
    }
}
