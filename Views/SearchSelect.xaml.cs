namespace FinalProjectLibraryManagerV01E.Views;

public partial class SearchSelect : ContentPage
{
	public SearchSelect()
	{
		InitializeComponent();
	}
<<<<<<< HEAD

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
=======
    private void OnSearchClicked(object sender, EventArgs e)
    {        
        string title = TitleEntry.Text;
        string author = AuthorEntry.Text;
        string category = CategoryEntry.Text;        
>>>>>>> 6be35bbfa84f15bf56cd966f0ee94b8e955ab122
    }
}