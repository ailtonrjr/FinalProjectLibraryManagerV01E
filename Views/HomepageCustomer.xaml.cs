using System.Formats.Tar;
using System.Reflection.Metadata;
using Microsoft.Maui.Controls;
using System;

namespace FinalProjectLibraryManagerV01E.Views;

	public partial class  HomepageCustomer : ContentPage
	{
		public HomepageCustomer()
		{
			InitializeComponent();
            BindName();
    }

    private void HomeUserBtn_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("..");
    }

    private void ReservationUserBtn_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(YourReservationsUser));
    }

    private void LoansUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourLoansUser));
    }

    private void FinesPaymentsUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(YourFinesPaymentsUser));
    }

    private void SearchUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(SearchSelectUser));
    }
    public void BindName()
    {
        Welcome_entry.Text = $" Hello! {LoginPage.CurrentUser.Name}";
    }

    private void LogoutHomeUserBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}
