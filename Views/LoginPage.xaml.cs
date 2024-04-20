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

    private async void loginBtn_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            await VerifyUserIdAndPasswd();

            if (userRadioButton.IsChecked)
            {
                await Shell.Current.GoToAsync(nameof(HomepageCustomer));
            }
            else if (adminRadioButton.IsChecked)
            {
                await Shell.Current.GoToAsync(nameof(HomepageLibrarian));
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "Please verify your UserID and/or password and try again", "OK");
            await Shell.Current.GoToAsync("..");
        }
        finally
        {
            entryUserID.Text = "";
            entryPAssword.Text = "";
            userRadioButton.IsChecked = false;
            adminRadioButton.IsChecked = false;
        }
    }

    public async Task VerifyUserIdAndPasswd()
    {
        try
        {
            int ID = Convert.ToInt32(entryUserID.Text);
            string password = entryPAssword.Text;  
            Models.Managers.DatabaseManager databaseManager = new Models.Managers.DatabaseManager();

            
            IUser user = databaseManager.VerifyLogin(ID, password);

            if (user == null)
            {
                throw new Exception("No user found with the provided ID and password.");
            }

            if (databaseManager.IsInstructor)
            {
                user = new Instructor(user.Name, user.ID, user.Password);
                CurrentUser = user;
                CurrentUser.IsStudent = false;
            }
            else
            {
                user = new Student(user.Name, user.ID, user.Password);
                CurrentUser = user;
                CurrentUser.IsStudent = true;
            }
        }
        catch (Exception ex)
        {
            // Re-throw the exception to be handled in the calling method
            throw new Exception("Failed to verify user. Please check the credentials and try again.", ex);
        }
    }
    public IUser GetUser()
    {
        return this.user;
    }

}