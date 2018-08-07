using GrowersClassified.Data;
using GrowersClassified.Models;
using GrowersClassified.Views.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowersClassified.Views.Account
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccountPage : ContentPage
	{
        public AccountPage()
        {
            InitializeComponent();
            // Check if user is connected to internet, if not, skip this
            if (CheckNetwork.IsInternet())
            {
                var userDatabase = new UserDatabase();
                var userdata = userDatabase.GetAllUsers();
                if (userdata.Count < 1)
                {
                    BtnLoginProcess.IsVisible = true;
                    LblAccountText.IsVisible = true;
                    LblUserName.IsVisible = false;
                    BtnLogoutProcess.IsVisible = false;
                    BtnRegisterProcess.IsVisible = true;
                }
                else
                {
                    var Displayname = userdata.First().Displayname;
                    BtnLoginProcess.IsVisible = false;
                    LblUserName.Text = "Welcome " + Displayname;
                    LblUserName.TextColor = Color.White;
                    LblUserName.IsVisible = true;
                    LblAccountText.IsVisible = false;
                    BtnLogoutProcess.IsVisible = true;
                    BtnRegisterProcess.IsVisible = false;
                }
            }
            else
            {
                BtnLoginProcess.IsVisible = false;
                LblAccountText.IsVisible = false;
                BtnLogoutProcess.IsVisible = false;
                BtnRegisterProcess.IsVisible = false;
                LblUserName.IsVisible = false;
                LblAccountText.IsVisible = false;
                ErrMessage.IsVisible = true;
                ErrMessage.TextColor = Color.Red;
                ErrMessage.Text = "You're not connected to the internet. Please make sure you are connected to use the app.";
            }

        }

        private async void ToLoginPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void ToRegisterPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void BtnLogoutProcess_Clicked(object sender, EventArgs e)
        {
            var userDatabase = new UserDatabase();
            var WP_Id = userDatabase.GetAllUsers().First().WP_Id;
            var userdata = userDatabase.DeleteUser(WP_Id);
            //var userDatabase = new UserDatabase();
            //userDatabase.LogoutUser();
            await Navigation.PushAsync(new AccountPage());
        }
    }
}