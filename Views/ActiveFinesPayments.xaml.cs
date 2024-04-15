namespace FinalProjectLibraryManagerV01E.Views;

public partial class ActiveFinesPayments : ContentPage
{
	public ActiveFinesPayments()
	{
		InitializeComponent();
	}

    private void homeFinPayBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomepageLibrarian));
    }

    private void booksFinPayBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(BooksPage));
    }

    private void userFinPayBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(StudentsInstructors));
    }

    private void searchFinPayBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchSelect));
    }

    private void reservationsFinPayBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ReservationPage));
    }

    private void loansFinPayBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoansPage));
    }
}