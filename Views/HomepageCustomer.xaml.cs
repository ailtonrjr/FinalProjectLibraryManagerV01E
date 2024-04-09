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
		}

    private void HomeUserBtn_Clicked_1(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}
