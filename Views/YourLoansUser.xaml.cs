namespace FinalProjectLibraryManagerV01E.Views;

public partial class YourLoansUser : ContentPage
{
	public YourLoansUser()
	{
		InitializeComponent();
	}

    private void homeLoanUserBtn_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(HomepageCustomer));
    }

    private void SearchLoanUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchSelectUser));
    }

    private void YourReservationLoanUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourReservationsUser));
    }

    private void FinesPaymentsLoanUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourFinesPaymentsUser));
    }

    private void LogoutLoansUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}