using FinalProjectLibraryManagerV01E.Models;
using Microsoft.Maui.Controls;
using System;

namespace FinalProjectLibraryManagerV01E.Views;

public partial class LoginPage : ContentPage
{
    public static IUser CurrentUser { get; set; }
    public IUser user;
    public int ID;
    private string password;
	public LoginPage()
	{
        
        InitializeComponent();

    }

    private void loginBtn_Clicked_1(object sender, EventArgs e)
    {
        VerifyUserIdAndPasswd();

        if (userRadioButton.IsChecked == true)
        {
            Shell.Current.GoToAsync(nameof(HomepageCustomer));
        }
        
        else if (adminRadioButton.IsChecked == true) 
        
        {
            Shell.Current.GoToAsync(nameof(HomepageLibrarian));
        }

        entryUserID.Text = "";
        entryPAssword.Text = "";
        userRadioButton.IsChecked = false;
        adminRadioButton.IsChecked = false;

    }

    public void VerifyUserIdAndPasswd()
    {
        ID = Convert.ToInt32(entryUserID.Text);
        password = entryPAssword.Text;
        Models.Managers.DatabaseManager databaseManager = new Models.Managers.DatabaseManager();
        user = databaseManager.VerifyLogin(ID, password);

        user = new Student(user.Name, user.ID, user.Password);
        CurrentUser = user;
        //}
        //else
        //{
        //    user = new Instructor(user.Name,user.ID,user.Password);

        //}
    }
    public IUser GetUser()
    {
        return this.user;
    }

}