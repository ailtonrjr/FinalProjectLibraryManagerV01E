using FinalProjectLibraryManagerV01E.Models;
using FinalProjectLibraryManagerV01E.Models.Managers;
using System;
using System.Collections.ObjectModel;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class LoansPage : ContentPage
{
    public ObservableCollection<Models.Loan> LoansHistory { get; set; } = new ObservableCollection<Models.Loan>();


    
    public LoansPage()
	{
		InitializeComponent();

        //LoadLoanHistory();
        BindData();

        //LoanHistoryListView.ItemsSource = LoansHistory;
    }

    //private void LoadLoanHistory()
    //{
    //    LoansHistory.Add(new Loan { Title = "Book 1", DueDate = DateTime.Today.AddDays(7) });
    //    LoansHistory.Add(new Loan { Title = "Book 2", DueDate = DateTime.Today.AddDays(14) });
    //    LoansHistory.Add(new Loan { Title = "Book 3", DueDate = DateTime.Today.AddDays(21) });
    //}

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

    private void LogoutLoansAdminBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoginPage));
    }
    public List<Models.Loan> GetAllLoan()
    {
        LoanManager loanManager = new LoanManager();
        List<Models.Loan> loans=loanManager.GetAllLoanFromManager();
        return loans;
    }
    public void BindData()
    {
        List<Models.Loan> loans = GetAllLoan();
        foreach(Models.Loan loan in loans)
        {
            LoansHistory.Add(loan);
        }
        LoanHistoryListView.ItemsSource = LoansHistory;
    }
}