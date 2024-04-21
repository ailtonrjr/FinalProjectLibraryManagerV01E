using FinalProjectLibraryManagerV01E.Models.Managers;
using FinalProjectLibraryManagerV01E.Models;


namespace FinalProjectLibraryManagerV01E.Views;

public partial class SearchSelectUser : ContentPage
{
	public SearchSelectUser()
	{
        InitializeComponent();
	}
    Book CurrentBook { get; set; }
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
            BookManager bookManager = new BookManager();
            foundBooks = bookManager.SearchBookByTitle(insertedTitle);
        }
        else if (authorSearchBtnUser.IsChecked == true)  // Changed to else if to avoid overwriting foundBooks
        {
            BookManager bookManager = new BookManager();
            foundBooks = BookManager.SearchBooksByAuthor( insertedAuthor);
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
        CurrentBook = foundBooks[selectedIndex];

        if (selectedIndex < 0) { }

        else
        {
            titleFoundEntryUser.Text = foundBooks[selectedIndex].Title;
            AuthorFoundEntryUser.Text = foundBooks[selectedIndex].Author;
            nameReservationNameUser.Text=LoginPage.CurrentUser.Name;
            RatingLabel.Text = foundBooks[selectedIndex].Rating.ToString();
            //isAvailableFoundEntry.Text = foundBooks[selectedIndex].isAvailable.ToString();

        }

    }

    private async void finalReserveBtnUser_Clicked(object sender, EventArgs e)
    {
        string titleSelected = titleFoundEntryUser.Text;
        string authorSelected = AuthorFoundEntryUser.Text;
        string nameUserSelected = nameReservationNameUser.Text;
        Book selectedBook = new Book();

        BookManager bookManager=new BookManager();
        List<Book> b1 = bookManager.SearchBookByFullTitle(titleSelected);
        if (b1 != null)
        {  // Ensure there are books found before assigning
            Book book = b1.First();  // Using the first found book
            //selectedBook = new Book { Title = book.Title, Author = book.Author };
            selectedBook = book;
        }

        else
        {
            b1 = bookManager.SearchBookByAuthor(authorSelected);
            Book book = b1.First();  // Using the first found book
            //selectedBook = new Book { Title = book.Title, Author = book.Author };
            selectedBook = book;

        }

        ReservationManager reservationManager = new ReservationManager();

        Student selectedStudent = UserManager.IstheUserRegistered(nameUserSelected);
        Student student = (Student)LoginPage.CurrentUser;
        if (selectedBook != null && selectedStudent != null)
        {
            var reservation = new Reservation
            {
                Book = selectedBook,
                Student = student,
                DateReserved = DateTime.Now,            };

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

    private void LogoutSearchUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoginPage));
    }

    private void ChangeRating_Clicked(object sender, EventArgs e)
    {
        
        string StringRating=ChangeRatingEntry.Text;
        float Rating = 0.0f;
        if (float.TryParse(StringRating, out Rating))
        {
            if (Rating > 5)
            {
                ChangeRatingEntry.Text = "Invalid";
            }
            else
            {
                BookManager bookManager = new BookManager();
                bookManager.ChangeRating(Rating, CurrentBook);
                ChangeRatingEntry.Text = "";
                RatingLabel.Text=bookManager.GetRating(CurrentBook.ISBN).ToString();    
            }
        }
        else
        {
            ChangeRatingEntry.Text = "Invalid";
        }
    }
}