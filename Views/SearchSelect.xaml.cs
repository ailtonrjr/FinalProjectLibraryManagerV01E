using FinalProjectLibraryManagerV01E.Models;
using FinalProjectLibraryManagerV01E.Models.Managers;
using System.Collections.ObjectModel;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class SearchSelect : ContentPage
{
    public SearchSelect()
    {
        InitializeComponent();

    }

    List<Book> foundBooks = new List<Book>();
    int selectedIndex;

    private void homeSearchBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomepageLibrarian));
    }

    private void booksSearchBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(BooksPage));
    }

    private void usersSearchBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(StudentsInstructors));
    }

    private void reservationsSearchBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ReservationPage));
    }

    private void loansSearchBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoansPage));
    }

    private void finesPaymentsSearchBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ActiveFinesPayments));
    }

    private void LogoutSearchAdminBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    //private void bookSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    //{
    //    var books = new ObservableCollection<Books>((IEnumerable<Books>)BookManager.SearchForBooks(bookSearchBar.Text));
    //    listOfBooks.ItemsSource = books;
    //}

    //private void listOfBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    //{
    //    if (listOfBooks.SelectedItem != null)
    //    {
    //        //DisplayAlert("Student", "A Student was clicked", "Ok");
    //        //Routes to Edit Student Page when an item is selected
    //        Shell.Current.GoToAsync($"{nameof(Reservation)}" + $"?Title={((Book)listOfBooks.SelectedItem).Title}");
    //    }
    //}

    private void listOfBooks_ItemTapped(object sender, ItemTappedEventArgs e)
    {

    }



    private void SearchButton_Clicked(object sender, EventArgs e)
    {
        string insertedTitle = TitleEntry.Text;  // Corrected variable names
        string insertedAuthor = authorEntry.Text; // Corrected variable names

        if (titleSearchBtn.IsChecked == true)
        {
            foundBooks = BookManager.SearchBooksByTitleFull(filterText: insertedTitle);
        }
        else if (authorSearchBtn.IsChecked == true)  // Changed to else if to avoid overwriting foundBooks
        {
            foundBooks = BookManager.SearchBooksByAuthorFull(filterText: insertedAuthor);
        }

        searchPicker.Items.Clear();  // Clear previous items

        if (foundBooks.Any())  // Check if there are any books found
        {
            foreach (Book book in foundBooks)
            {
                searchPicker.Items.Add(book.ToDisplay());
            }
        }
        else
        {
            searchPicker = null;
        }
    }

    private void searchPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        selectedIndex = picker.SelectedIndex;

        if (selectedIndex < 0) { }

        else
        {
            titleFoundEntry.Text = foundBooks[selectedIndex].Title;
            AuthorFoundEntry.Text = foundBooks[selectedIndex].Author;
            //isAvailableFoundEntry.Text = foundBooks[selectedIndex].isAvailable.ToString();

        }

    }

    private async void finalReserveBtn_Clicked(object sender, EventArgs e)
    {
        string titleSelected = titleFoundEntry.Text;
        string authorSelected = AuthorFoundEntry.Text;
        string nameUserSelected = nameReservationName.Text;
        Book selectedBook = null;


        List<Book> b1 = BookManager.SearchBooksByAuthorFull(filterText: authorSelected);
        if (b1 != null)
        {  // Ensure there are books found before assigning
            Book book = b1.First();  // Using the first found book
            selectedBook = new Book { Title = book.Title, Author = book.Author };
        }

        else
        {
            b1 = BookManager.SearchBooksByTitleFull(filterText: titleSelected);
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
                ReservationDueDate = DateTime.Today
            };

            reservationManager.AddReservation(reservation);

            await DisplayAlert("Reservation", "Your reservation has been created!", "OK");

            titleSearchBtn.IsChecked = false;
            authorSearchBtn.IsChecked = false;
            TitleEntry.Text = "";
            authorEntry.Text = "";
            searchPicker.Items.Clear();
            titleFoundEntry.Text = "";
            AuthorFoundEntry.Text = "";
            nameReservationName.Text = "";
            foundBooks.Clear();

        }
        else
        {
            new Exception("No books found!");
        }

    }


    //=======
    //    private void OnSearchClicked(object sender, EventArgs e)
    //    {        
    //        string title = TitleEntry.Text;
    //        string author = AuthorEntry.Text;
    //        string category = CategoryEntry.Text;        
    ////>>>>>>> 6be35bbfa84f15bf56cd966f0ee94b8e955ab122
    //    }
}