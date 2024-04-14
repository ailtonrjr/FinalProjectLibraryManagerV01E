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

    private void homeSearchBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
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
        Shell.Current.GoToAsync(nameof(Reservation));
    }

    private void loansSearchBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoansPage));
    }

    private void finesPaymentsSearchBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ActiveFinesPayments));
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

    private void searchPicker_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    //private void SearchButton_Clicked(object sender, EventArgs e)
    //{
    //    string insertedTitle = searchForAuthor.Text;
    //    string insertedAuthor = searchForTitle.Text;

    //    List<Book> foundBooks = new List<Book>();

    //    if (title_clicked)
    //    {
    //        foundBooks = BookManager.SearchBooksByTitle(title : insertedTitle);
    //    }

    //    if (author_clicked)
    //    {
    //        foundBooks = BookManager.SearchBooksByAuthor(author : insertedAuthor);
    //    }

    //    foreach (Book book in foundBooks)
    //    {
    //        if (book != null)
    //        {
    //            //mostrar no picker
    //            searchPicker.Items.Add(book.ToDisplay());
    //        }

    //        else
    //        {
    //            //mostrar no picker
    //            searchPicker.Items.Add(book.ToDisplay());
    //        }

    //    }

    //}
    //=======
    //    private void OnSearchClicked(object sender, EventArgs e)
    //    {        
    //        string title = TitleEntry.Text;
    //        string author = AuthorEntry.Text;
    //        string category = CategoryEntry.Text;        
    ////>>>>>>> 6be35bbfa84f15bf56cd966f0ee94b8e955ab122
    //    }
}