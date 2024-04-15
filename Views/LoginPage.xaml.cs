using Microsoft.Maui.Controls;
using System;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private void loginBtn_Clicked_1(object sender, EventArgs e)
    {
        
        if(userRadioButton.IsChecked == true)
        {
            Shell.Current.GoToAsync(nameof(HomepageCustomer));
        }
        
        else if (adminRadioButton.IsChecked == true) 
        
        {
            Shell.Current.GoToAsync(nameof(HomepageLibrarian)); ;
        }
        
    }
}