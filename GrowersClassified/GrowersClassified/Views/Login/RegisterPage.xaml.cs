using GrowersClassified.Data;
using GrowersClassified.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowersClassified.Views.Login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        // Redirect to LoginPage
        private async void ToLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async Task RegisterProcess_Clicked(object sender, EventArgs e)
        {
            // Check if user has an internet connection. If there IS a connection, continue with the login process
            if (CheckNetwork.IsInternet())
            {
                // Creating new user and setting Username and Password to the input from the login page
                var user = new User
                {
                    Username = Entry_Username.Text,
                    Password = Entry_Pass.Text,
                    Email = Entry_Email.Text,
                    Nicename = Entry_Nicename.Text,
                };

                if (Entry_Username.Text != null && Entry_Pass.Text != null && Entry_ConfirmPass.Text != null && Entry_Email.Text != null && Entry_Nicename.Text != null)
                {
                    if(Entry_Pass.Text == Entry_ConfirmPass.Text)
                    {
                        var result = await App.RestService.Register(user);
                        Console.WriteLine(result);
                    }
                    else
                    {
                        RegisterMessage.TextColor = Color.Red;
                        RegisterMessage.Text = "Password and Confirm password do not match. Please revise and try again.";
                    }
                }
            }
            // If user does not have an internetconnection, return this error
            else
            {
                RegisterMessage.TextColor = Color.Red;
                RegisterMessage.Text = "You're not connected to the internet!";
            }

        }
}