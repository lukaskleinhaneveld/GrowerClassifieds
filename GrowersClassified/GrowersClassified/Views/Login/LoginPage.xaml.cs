using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrowersClassified.Data;
using GrowersClassified.Models;
using GrowersClassified.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowersClassified.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async Task LoginProcess_Clicked()
        {
            if (CheckNetwork.IsInternet())
            {
                var user = new User
                {
                    Email = Entry_Email.Text,
                    Password = Entry_Pass.Text
                };

                if (user.Email == null || user.Password == null)
                {
                    LoginMessage.TextColor = Color.Red;
                    LoginMessage.Text = "Email or password field is empty";
                }
                else
                {
                    LoginMessage.TextColor = Color.SpringGreen;
                    LoginMessage.Text = "Logging in! please wait.....";
                    var result = await App.LoginService.Login(user);
                    var dbclear = new UserDatabase();
                    dbclear.Droptable();
                    if (result.AccessToken != null)
                    {
                        //var userDatabase = new UserDatabase();
                        //userDatabase.AddUser(result);
                        Entry_Email.Text = "";
                        Entry_Pass.Text = "";
                        LoginMessage.Text = "Logged in!";
                        CurrentUser.IsUserLoggedIn = true;
                        CurrentUser.Displayame = result.Displayname;
                        await Navigation.PopToRootAsync();
                    }
                    else
                    {
                        LoginMessage.TextColor = Color.Red;
                        LoginMessage.Text = "Invalid login information... please try again!";

                    }
                    dbclear.Droptable();
                }
            }
            else
            {
                LoginMessage.TextColor = Color.Red;
                LoginMessage.Text = "You're not connected to the internet!";
            }
        }

        public async void ToRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }
    }
}