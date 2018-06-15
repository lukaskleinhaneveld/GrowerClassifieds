using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrowersClassified.Data;
using GrowersClassified.Models;
using GrowersClassified.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

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
                    Username = Entry_Username.Text,
                    Password = Entry_Pass.Text
                };

                if (user.Username == null || user.Password == null)
                {
                    LoginMessage.TextColor = Color.Red;
                    LoginMessage.Text = "Email or password field is empty";
                }
                else
                {
                    LoginMessage.TextColor = Color.SpringGreen;
                    LoginMessage.Text = "Logging in! please wait.....";
                    var result = await App.LoginService.Login(user);
                    Console.WriteLine("************    #RESULT    *************");
                    Console.WriteLine(result);
                    Console.WriteLine("At least know I'm here...");
                    Console.WriteLine("************    /RESULT    *************");
                    var dbclear = new UserDatabase();
                    dbclear.Droptable();
                    if (result.AccessToken != null)
                    {
                        var userDatabase = new UserDatabase();
                        userDatabase.AddUser(result);

                        var userdata = userDatabase.GetAllUsers();
                        var displayname = userdata.First().Displayname;
                        CurrentUser.Displayname = displayname;


                        Entry_Username.Text = "";
                        Entry_Pass.Text = "";
                        LoginMessage.Text = "Logged in!";
                        CurrentUser.IsUserLoggedIn = true;
                        CurrentUser.Displayname = result.Displayname;
                        Navigation.InsertPageBefore(new Index(), this); await Navigation.PopAsync(true);

                    }
                    else
                    {
                        LoginMessage.TextColor = Color.Red;
                        LoginMessage.Text = "Invalid login information... please try again!";

                    }
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