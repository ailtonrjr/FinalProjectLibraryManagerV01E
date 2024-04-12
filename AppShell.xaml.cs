﻿using FinalProjectLibraryManagerV01E.Views;

namespace FinalProjectLibraryManagerV01E
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomepageLibrarian), typeof(HomepageLibrarian));
            Routing.RegisterRoute(nameof(HomepageCustomer), typeof(HomepageCustomer));
            Routing.RegisterRoute(nameof(ActiveFinesPayments), typeof(ActiveFinesPayments));
            Routing.RegisterRoute(nameof(Active_Loans), typeof(Active_Loans));
            Routing.RegisterRoute(nameof(Books), typeof(Books));
            Routing.RegisterRoute(nameof(LoansHistory), typeof(LoansHistory));
            Routing.RegisterRoute(nameof(Reservation), typeof(Reservation));
            Routing.RegisterRoute(nameof(SearchSelect), typeof(SearchSelect));
            Routing.RegisterRoute(nameof(StudentsInstructors), typeof(StudentsInstructors));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(BooksPage), typeof(BooksPage));
            Routing.RegisterRoute(nameof(LoansPage), typeof(LoansPage));
            Routing.RegisterRoute(nameof(YourReservationsUser), typeof(YourReservationsUser));
            Routing.RegisterRoute(nameof(YourLoansUser), typeof(YourLoansUser));
            Routing.RegisterRoute(nameof(YourFinesPaymentsUser), typeof(YourFinesPaymentsUser));
            Routing.RegisterRoute(nameof(SearchSelectUser), typeof(SearchSelectUser));
        }
    }
}
