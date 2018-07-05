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

        private async void ToLoginPage_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
        }

        private async void ToRegisterPage_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new RegisterPage(), this);
            await Navigation.PopAsync();
        }

        private async void BtnLogoutProcess_Clicked(object sender, EventArgs e)
        {
            var userDatabase = new UserDatabase();
            var id = userDatabase.GetAllUsers().First().Id;
            var userdata = userDatabase.DeleteUser(id);
            Navigation.InsertPageBefore(new AccountPage(), this);
            await Navigation.PopAsync();
        }
    }
}