using FinalProjectLibraryManagerV01E.Models;
using FinalProjectLibraryManagerV01E.Models.Managers;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class YourLoansUser : ContentPage
{
	public YourLoansUser()
	{
		InitializeComponent();
        BindLoans();
	}

    private void homeLoanUserBtn_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(HomepageCustomer));
    }

    private void SearchLoanUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchSelectUser));
    }

    private void YourReservationLoanUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourReservationsUser));
    }

    private void FinesPaymentsLoanUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourFinesPaymentsUser));
    }

    private void LogoutLoansUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
    public List<Models.Loan> GetLoans()
    {
        List<Models.Loan>loans=new List<Models.Loan>();
        LoanManager loanManager=new LoanManager();
        loans = loanManager.GetLoanFromDatabase(LoginPage.CurrentUser);
        return loans;
    }

    public void BindLoans()
    {
        List<Models.Loan>loans=new List<Models.Loan>();
        List<string> StringLoans = new List<string>();    
        loans = GetLoans();
        foreach(Loan loan in loans)
        {
            StringLoans.Add(loan.ToString());
        }
        LoanList.ItemsSource = loans;
        
    }

    

}