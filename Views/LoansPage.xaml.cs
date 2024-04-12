using FinalProjectLibraryManagerV01E.Models;
using System;
using System.Collections.ObjectModel;


namespace FinalProjectLibraryManagerV01E.Views
{
<<<<<<< HEAD
	public LoansPage()
	{
		InitializeComponent();
	}

    private void homeLoanBtn_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    private void booksLoanBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(BooksPage));
    }

    private void userLoanBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(StudentsInstructors));
    }

    private void searchLoanBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchSelect));
    }

    private void reservationsLoanBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(Reservation));
    }

    private void finesPaymentsLoanBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ActiveFinesPayments));
=======
    public partial class LoansPage : ContentPage
    {
        public ObservableCollection<Loan> LoansHistory { get; set; }

        
        public class Loan
        {
            public string Title { get; set; }
            public DateTime DueDate { get; set; }
        }

        public LoansPage()
        {
            InitializeComponent();

            LoansHistory = new ObservableCollection<Loan>();

            
            LoadLoanHistory();

            
            LoanHistoryListView.ItemsSource = LoansHistory;
        }

        
        private void LoadLoanHistory()
        {
            
            LoansHistory.Add(new Loan { Title = "Book 1", DueDate = DateTime.Today.AddDays(7) });
            LoansHistory.Add(new Loan { Title = "Book 2", DueDate = DateTime.Today.AddDays(14) });
            LoansHistory.Add(new Loan { Title = "Book 3", DueDate = DateTime.Today.AddDays(21) });
        }
>>>>>>> 6be35bbfa84f15bf56cd966f0ee94b8e955ab122
    }
}