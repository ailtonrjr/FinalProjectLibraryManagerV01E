using FinalProjectLibraryManagerV01E.Models;
using System;
using System.Collections.ObjectModel;


namespace FinalProjectLibraryManagerV01E.Views
{
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
    }
}