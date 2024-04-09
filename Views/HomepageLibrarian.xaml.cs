using Microsoft.Maui.Controls;
using System;


namespace FinalProjectLibraryManagerV01E.Views;

public partial class HomepageLibrarian : ContentPage
{
	public HomepageLibrarian()
	{
        InitializeComponent();

        //HomeAdmBtn.MouseEnter += OnButtonMouseEnter;
        //HomeAdmBtn.MouseLeave += OnButtonMouseLeave;
    }

    private void HomeAdmBtn_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(HomepageCustomer));
    }

    private void LoginAdmBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoginPage));
    }

    
}