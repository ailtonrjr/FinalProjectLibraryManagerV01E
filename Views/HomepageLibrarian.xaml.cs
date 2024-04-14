using FinalProjectLibraryManagerV01E.Models;
using Microsoft.Maui.Controls;
using System;


namespace FinalProjectLibraryManagerV01E.Views;

public partial class HomepageLibrarian : ContentPage
{
	public HomepageLibrarian()
	{
        InitializeComponent();

        //HomeAdmBtn.MouseEnter += OnButtonMouseEnter;
        //HomeAdmBtn.MouseLeave += OnButtonMouseLeave;
    }

    private void HomeAdmBtn_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(HomepageCustomer));
    }

    private void LoginAdmBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoginPage));
    }

    private void BooksAdmBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(Books));
    }

    private void StudentsAdmBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(StudentsInstructors));
    }

    private void SearchAdmBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchSelect));
    }

    private void ReservationsAdmBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(Reservation));
    }

    private void LoansAdmBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoansPage));
    }

    private void FinesAndPaymentsAdmBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ActiveFinesPayments));
    }

    private void Test_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(BooksPage));
    }
}