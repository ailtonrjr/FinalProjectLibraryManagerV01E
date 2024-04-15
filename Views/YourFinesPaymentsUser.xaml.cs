using System.Formats.Tar;
using System.Reflection.Metadata;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FinalProjectLibraryManagerV01E.Models;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class YourFinesPaymentsUser : ContentPage
{
    public ObservableCollection<Fine> UserFines { get; set; }
    public YourFinesPaymentsUser()
	{
        InitializeComponent();
        UserFines = new ObservableCollection<Fine>();
        //LoadFines();
        //FinesCollectionView.ItemsSource = UserFines;
    }

    private void homeFinPayUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomepageCustomer));
    }

    private void SearchFinPayUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchSelectUser));
    }

    private void YourReservationFinPayUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourReservationsUser));
    }

    private void LoansFinPayUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourLoansUser));
    }

    //private void LoadFines()
    //{
    //    // Example fines, load from your data source
    //    UserFines.Add(new Fine { ID = "1", FineTitle = "Overdue: 'C# in Depth'", Amount = 5 });
    //    UserFines.Add(new Fine { ID = "2", FineTitle = "Overdue: 'Introduction to Algorithms'", Amount = 3 });
    //    UserFines.Add(new Fine { ID = "3", FineTitle = "Damaged: 'The Pragmatic Programmer'", Amount = 12 });
    //}

    private async void OnPayClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var iD = (string)button.CommandParameter;
        // Handle the payment logic here
        // For now, let's just display an alert
        await DisplayAlert("Payment", $"Payment for Fine ID: {iD}", "OK");
    }
}