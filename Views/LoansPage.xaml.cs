using FinalProjectLibraryManagerV01E.Models;
using System;
using System.Collections.ObjectModel;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class LoansPage : ContentPage
{
    public ObservableCollection<Loan> LoansHistory { get; set; } = new ObservableCollection<Loan>();


    public class Loan
    {
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
    }
    public LoansPage()
	{
		InitializeComponent();

        LoadLoanHistory();

        LoanHistoryListView.ItemsSource = LoansHistory;
    }

    private void LoadLoanHistory()
    {
        LoansHistory.Add(new Loan { Title = "Book 1", DueDate = DateTime.Today.AddDays(7) });
        LoansHistory.Add(new Loan { Title = "Book 2", DueDate = DateTime.Today.AddDays(14) });
        LoansHistory.Add(new Loan { Title = "Book 3", DueDate = DateTime.Today.AddDays(21) });
    }

    private void homeLoanBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomepageLibrarian));
    }

    private void booksLoanBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(Book));
    }

    private void usersLoanBtn_Clicked(object sender, EventArgs e)
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
    }

    
}