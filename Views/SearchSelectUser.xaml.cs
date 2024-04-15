using FinalProjectLibraryManagerV01E.Models.Managers;
using FinalProjectLibraryManagerV01E.Models;


namespace FinalProjectLibraryManagerV01E.Views;

public partial class SearchSelectUser : ContentPage
{
	public SearchSelectUser()
	{
        InitializeComponent();
	}

    List<Book> foundBooks = new List<Book>();
    int selectedIndex;

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

    private void SearchButtonUser_Clicked(object sender, EventArgs e)
    {
        string insertedTitle = TitleEntryUser.Text;  // Corrected variable names
        string insertedAuthor = authorEntryUser.Text; // Corrected variable names

        if (titleSearchBtnUser.IsChecked == true)
        {
            foundBooks = BookManager.SearchBooksByTitle(title: insertedTitle);
        }
        else if (authorSearchBtnUser.IsChecked == true)  // Changed to else if to avoid overwriting foundBooks
        {
            foundBooks = BookManager.SearchBooksByAuthor(author: insertedAuthor);
        }

        searchPickerUser.Items.Clear();  // Clear previous items

        if (foundBooks.Any())  // Check if there are any books found
        {
            foreach (Book book in foundBooks)
            {
                searchPickerUser.Items.Add(book.ToDisplay());
            }
        }
        else
        {
            searchPickerUser.Items.Add("Book not found");  // Handle no books found
        }
    }

    private void searchPickerUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        selectedIndex = picker.SelectedIndex;

        if (selectedIndex < 0) { }

        else
        {
            titleFoundEntryUser.Text = foundBooks[selectedIndex].Title;
            AuthorFoundEntryUser.Text = foundBooks[selectedIndex].Author;
            //isAvailableFoundEntry.Text = foundBooks[selectedIndex].isAvailable.ToString();

        }

    }

    private async void finalReserveBtnUser_Clicked(object sender, EventArgs e)
    {
        string titleSelected = titleFoundEntryUser.Text;
        string authorSelected = AuthorFoundEntryUser.Text;
        string nameUserSelected = nameReservationNameUser.Text;
        Book selectedBook = null;


        List<Book> b1 = BookManager.SearchBooksByTitle(titleSelected);
        if (b1.Any())
        {  // Ensure there are books found before assigning
            Book book = b1.First();  // Using the first found book
            selectedBook = new Book { Title = book.Title, Author = book.Author };
        }

        ReservationManager reservationManager = new ReservationManager();
        Student selectedStudent = UserManager.IstheUserRegistered(nameUserSelected);

        if (selectedBook != null && selectedStudent != null)
        {
            var reservation = new Reservation
            {
                Book = selectedBook,
                Student = selectedStudent,
                ReservationDate = DateTime.Today
            };

            reservationManager.AddReservation(reservation);

            await DisplayAlert("Reservation", "Your reservation has been created!", "OK");

            titleSearchBtnUser.IsChecked = false;
            authorSearchBtnUser.IsChecked = false;
            TitleEntryUser.Text = "";
            authorEntryUser.Text = "";
            searchPickerUser.Items.Clear();
            titleFoundEntryUser.Text = "";
            AuthorFoundEntryUser.Text = "";
            nameReservationNameUser.Text = "";
            foundBooks.Clear();

        }
        else
        {
            // Throw an exception
        }

        //searchPickerUser.Items.Clear();
        //titleFoundEntryUser.Text = "";
        //AuthorFoundEntryUser.Text = "";
        //nameReservationNameUser.Text = "";
        //foundBooks.Clear();


        //if (UserManager.IstheUserRegistered(nameUserSelected) == true)
        //{

        //    //preciso de um objeto Book, um objeto Student e datetime (today)
        //    //new Reservation { };
        //}

    }
}