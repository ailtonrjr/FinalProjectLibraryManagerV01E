using FinalProjectLibraryManagerV01E.Models.Managers;
using FinalProjectLibraryManagerV01E.Models;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class SearchSelectUser : ContentPage
{
	public SearchSelectUser()
	{
        InitializeComponent();
	}

    private void homeSearchUserBtn_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(HomepageCustomer));
    }

    private void YourReservationSearchUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourReservationsUser));
    }

    private void LoansSearchUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourLoansUser));
    }

    private void FinesPaymentsSearchUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourFinesPaymentsUser));
    }

    private void SearchButton_ClickedUser(object sender, EventArgs e)
    {
        //    string insertedTitle = searchForAuthor.Text;
        //    string insertedAuthor = searchForTitle.Text;


        //    List<Book> foundBooks = BookManager.SearchBooksCombined(insertedTitle, insertedAuthor);

        //    foreach (Book book in foundBooks)
        //    {
        //        if (book != null)
        //        {
        //            searchPicker.Items.Add(book.ToDisplay());
        //        }

        //        else
        //        {
        //            searchPicker.Items.Add("No books found");
        //        }

        //    }

    }
}