using FinalProjectLibraryManagerV01E.Models;
using FinalProjectLibraryManagerV01E.Models.Managers;
using System.Collections.ObjectModel;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class TestPage : ContentPage
{
	public TestPage()
	{
		InitializeComponent();

		
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        var books = new ObservableCollection<Book>(BookManager.GetAllBooks());
        Console.WriteLine($"Currently our collection has {books.Count} books."); // Add this to check how many books are loaded
        listOfBooks.ItemsSource = books; // Ensure this is correctly referring to your ListView
    }


    private void homeSearchBtn_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    //private void bkSearchBar_TextChanged(object sender, TextChangedEventArgs e)
    //{
    //    var books = new ObservableCollection<Book>(BookManager.SearchForBooks(bkSearchBar.Text));
    //    listOfBooks.ItemsSource = books;
    //}

    private void listOfBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listOfBooks.SelectedItem != null) 
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex < 0) 
            {
                foundBookTitle.Text = "Titulo";
                foundBookAuthor.Text = "Autor";
                
            }
        }
    }

    private void listOfBooks_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listOfBooks.SelectedItem = null;
    }
}