using FinalProjectLibraryManagerV01E.Models;
using Microsoft.Maui.Controls;

namespace FinalProjectLibraryManagerV01E.Views
{
    public partial class BooksPage : ContentPage
    {
        public BooksPage() 
        {
            InitializeComponent();
        }

        private async void OnBookTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Book selectedBook)
            {
                await Shell.Current.Navigation.PushAsync(new BookDetailPage(selectedBook));
            }
        }
    }
}
