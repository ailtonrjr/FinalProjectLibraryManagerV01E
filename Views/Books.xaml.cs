using FinalProjectLibraryManagerV01E.Models;
using FinalProjectLibraryManagerV01E.Models.Managers;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class Books : ContentPage
{
	public Books()
	{
		InitializeComponent();
	}

    private void homeBooksBtn_Clicked_1(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomepageLibrarian));
    }

    private void StudentsBookBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(StudentsInstructors));
    }

    private void searchBookBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchSelect));
    }

    private void reservationBookBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomepageCustomer));
    }

    private void loansBookBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoansPage));
    }

    private void finesPaymentsBookBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ActiveFinesPayments));
    }

    //private void addBookBtn_Clicked(object sender, EventArgs e)
    //{
    //    BookManager.AddBook(Book book);
    //}

    //private void deleteBookBtn_Clicked(object sender, EventArgs e)
    //{
    //    BookManager.DeleteBookd(Book book);
    //}
}