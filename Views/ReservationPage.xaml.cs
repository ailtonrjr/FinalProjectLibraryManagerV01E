using FinalProjectLibraryManagerV01E.Models;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class ReservationPage : ContentPage
{
    
    


    public ReservationPage()
    {
        InitializeComponent();
    }

    private void homeReserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomepageLibrarian));
    }


    private void homeReserBtn_Clicked_1(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void booksUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(BooksPage));
    }

    private void usersUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(StudentsInstructors));
    }

    private void searchUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchSelect));
    }

    private void loansUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoansPage));
    }

    private void finesPaymentsUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ActiveFinesPayments));
    }

    private void LogoutReservationsAdminBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}



