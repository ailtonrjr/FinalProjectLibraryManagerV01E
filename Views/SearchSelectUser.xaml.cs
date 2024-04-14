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

    private void searchPickerUser_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void SearchButtonUser_Clicked(object sender, EventArgs e)
    {
        string insertedTitleUser = searchForAuthorUser.Text;
        string insertedAuthorUser = searchForTitleUser.Text;


        List<Book> foundBooksUser = BookManager.SearchBooksCombined(insertedTitleUser, insertedAuthorUser);

        foreach (Book book in foundBooksUser)
        {
            if (book != null)
            {
                searchPickerUser.Items.Add(book.ToDisplay());
            }

            else
            {
                searchPickerUser.Items.Add("No books found");
            }

        }

    }
}