using System.Formats.Tar;
using System.Reflection.Metadata;
using Microsoft.Maui.Controls;
using System;
using FinalProjectLibraryManagerV01E.Models;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class YourReservationsUser : ContentPage
{
   
    public YourReservationsUser()
	{
		InitializeComponent();
        BindData();
	}

   
    private void HomeReservUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomepageCustomer));
    }

    private void SearchUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchSelectUser));
    }

    private void LoansUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourLoansUser));
    }

    private void FinesPaymentsUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourFinesPaymentsUser));
    }
   

    

    public void BindData()
    {
        List<string> StringReservations = new List<string>();
        List<Models.Reservation> reservations = new List<Models.Reservation>();
        Models.Managers.ReservationManager reservationManager = new Models.Managers.ReservationManager();
        LoginPage loginPage = new LoginPage();
        reservations = reservationManager.Getreservation(LoginPage.CurrentUser);
        foreach(Reservation reservation in reservations)
        {
            StringReservations.Add(reservation.ToString());
        }
        ReservationList.ItemsSource= StringReservations;
        //foreach(Reservation reservation in reservations)
        //{
        //    Reservation1.Text = $"Book Name={reservation.Book.Title}  User name={reservation.Instructor.Name} Date:{reservation.ReservationDueDate}";

        //}

    }
}