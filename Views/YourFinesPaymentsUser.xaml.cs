using System.Formats.Tar;
using System.Reflection.Metadata;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FinalProjectLibraryManagerV01E.Models;
using FinalProjectLibraryManagerV01E.Models.Managers;
using MySqlConnector;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class YourFinesPaymentsUser : ContentPage
{
    public ObservableCollection<Fine> UserFines { get; set; }
    public YourFinesPaymentsUser()
	{
        InitializeComponent();
        UserFines = new ObservableCollection<Fine>();
        BindFines();
        //LoadFines();
        //FinesCollectionView.ItemsSource = UserFines;
    }

    private void homeFinPayUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(HomepageCustomer));
    }

    private void SearchFinPayUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchSelectUser));
    }

    private void YourReservationFinPayUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourReservationsUser));
    }

    private void LoansFinPayUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourLoansUser));
    }

    //private void LoadFines()
    //{
    //    // Example fines, load from your data source
    //    UserFines.Add(new Fine { ID = "1", FineTitle = "Overdue: 'C# in Depth'", Amount = 5 });
    //    UserFines.Add(new Fine { ID = "2", FineTitle = "Overdue: 'Introduction to Algorithms'", Amount = 3 });
    //    UserFines.Add(new Fine { ID = "3", FineTitle = "Damaged: 'The Pragmatic Programmer'", Amount = 12 });
    //}

    private async void OnPayClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var FineID = (string)button.CommandParameter;
        // Handle the payment logic here
        // For now, let's just display an alert
        await DisplayAlert("Payment", $"Payment for Fine ID: {FineID}", "OK");
    }

    private void LogoutFinesUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoginPage));
    }
    public List<Fine> GetFines(IUser user)
    {
        List<Fine> fines = new List<Fine>();
        FineManager fineManager = new FineManager();
        fines = fineManager.GetFineFromDatabase(user);
        return fines;
    }

    public void BindFines()
    {
        List<Fine> fines=new List<Fine>();
        fines = GetFines(LoginPage.CurrentUser);
        BindingContext= fines;
    }

    //Test begin here:

    string connectionString;
    internal class BookLoan
    {
        public DateTime DueDate { get; internal set; }
        public bool IsReturned { get; internal set; }
        public string LoanID { get; internal set; }
        public string UserID { get; internal set; }
    }

    private async Task CheckAndApplyFine(BookLoan bookLoan)
    {
        // Assuming 'bookLoan' has a 'DueDate' property and an 'IsReturned' flag.
        if (bookLoan.DueDate < DateTime.Now && !bookLoan.IsReturned)
        {
            Fine newFine = new Fine
            {
                UserID = bookLoan.UserID, // Identifier of the user who borrowed the book.
                LoanID = bookLoan.LoanID, // Identifier of the loan transaction.
                UserType = GetUserType(bookLoan.UserID), // A method to retrieve the type of user (e.g., Student, Instructor).
                IsActive = true, // Assuming '1' denotes an active fine.
                FineAmount = CalculateFine(bookLoan.DueDate) // A method to calculate the fine based on how overdue the book is.
            };

        }
    }

    private string GetUserType(string userID)
    {
        // Implement logic to retrieve the user type based on the given userID.
        // This is just a placeholder.
        return "Student";
    }

    private int CalculateFine(DateTime dueDate)
    {
        // Implement logic to calculate the fine based on how overdue the book is.
        // This is just a placeholder.
        return (DateTime.Now - dueDate).Days * 2; //  $2 per day overdue.
    }

    public async Task AddFineToDatabase(Fine newFine)
    {
        // Connection and command setup
        using (var connection = new MySqlConnection(connectionString))
        using (var command = new MySqlCommand("INSERT INTO fine (UserID, LoanID, UserType, IsActive, FineAmount) VALUES (@UserID, @LoanID, @UserType, @IsActive, @FineAmount)", connection))
        {
            // Add parameters to prevent SQL injection
            command.Parameters.AddWithValue("@UserID", newFine.UserID);
            command.Parameters.AddWithValue("@LoanID", newFine.LoanID);
            command.Parameters.AddWithValue("@UserType", newFine.UserType);
            command.Parameters.AddWithValue("@IsActive", newFine.IsActive);
            command.Parameters.AddWithValue("@FineAmount", newFine.FineAmount);

            // Open connection, execute command and close connection
            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();

        }
    }
}