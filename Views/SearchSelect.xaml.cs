namespace FinalProjectLibraryManagerV01E.Views;

public partial class SearchSelect : ContentPage
{
	public SearchSelect()
	{
		InitializeComponent();
	}
    private void OnSearchClicked(object sender, EventArgs e)
    {        
        string title = TitleEntry.Text;
        string author = AuthorEntry.Text;
        string category = CategoryEntry.Text;        
    }
}