using Microsoft.Maui.Controls;

namespace FinalProjectLibraryManagerV01E.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            ButtonClickButton.Clicked += ButtonClickButton_Clicked;

            ButtonClickButton.Clicked += async (sender, e) =>
            {
                await Shell.Current.GoToAsync(nameof(BooksPage));
            };

        }

        private void ButtonClickButton_Clicked(object sender, EventArgs e)
        {
            DisplayLabel.Text = "Button clicked!";
        }
    }
}
