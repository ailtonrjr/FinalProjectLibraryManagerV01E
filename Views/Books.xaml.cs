using FinalProjectLibraryManagerV01E.Models;
using FinalProjectLibraryManagerV01E.Models.Managers;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class Books : ContentPage
{
	public Books()
	{
		InitializeComponent();
	}

    Book newBook;

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

    private async void addBookBtn_Clicked(object sender, EventArgs e)
    {
        
        string newBookTitle = newBookTitleEntry.Text;
        string newBookAuthor = newBookAuthorEntry.Text;
        string newBookISBN = newBookISBNEntry.Text;
        int newBookCopies = Convert.ToInt16(newBookCopiesEntry.Text);
        int newBookRate = Convert.ToInt16(newBookRatingEntry.Text);
        string newBookLocation = newBookLocationEntry.Text;

        if (!string.IsNullOrEmpty(newBookTitle) && !string.IsNullOrEmpty(newBookAuthor) && !string.IsNullOrEmpty(newBookISBN) && newBookCopies > 0 && newBookRate > 0 && !string.IsNullOrEmpty(newBookLocation))
        {
            Book newBook = new Book(newBookTitle, newBookAuthor, newBookISBN, newBookCopies, newBookRate, newBookLocation);
            DatabaseManager databaseManager = new DatabaseManager();
            databaseManager.AddToDatabse(newBook);

            await DisplayAlert("Book Added", "The book has been added to the library repository", "OK");

            newBookTitleEntry.Text = "";
            newBookAuthorEntry.Text = "";
            newBookISBNEntry.Text = "";
            newBookCopiesEntry.Text = "";
            newBookRatingEntry.Text = "";
            newBookLocationEntry.Text = "";

        }
    }

    private async void deleteBookBtn_Clicked(object sender, EventArgs e)
    {
        string deleteBookISBN = deleteBookISBNEntry.Text;

        if (!string.IsNullOrEmpty(deleteBookISBN))
        {
            DatabaseManager databaseManager = new DatabaseManager();
            await DisplayAlert("Book Deleted", "The book has been deleted from the library repository", "OK");
            databaseManager.DeleteBookFromDatabase(deleteBookISBN);

            
            deleteBookISBNEntry.Text = "";
        }

    }

    private void LogoutBooksAdminBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoginPage));

    }

    
    //private void deleteBookBtn_Clicked(object sender, EventArgs e)
    //{
    //    BookManager.DeleteBookd(Book book);
    //}
}