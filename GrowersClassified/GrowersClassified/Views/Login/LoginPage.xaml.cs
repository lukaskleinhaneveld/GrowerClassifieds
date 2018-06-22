using System;
using System.Threading.Tasks;
using GrowersClassified.Data;
using GrowersClassified.Models;
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

        // LoginProcess, this is being called from the Login button on the login page
        async Task LoginProcess_Clicked(object sender, EventArgs e)
        {
            // Check if user has an internet connection. If there IS a connection, continue with the login process
            if (CheckNetwork.IsInternet())
            {
                // Creating new user and setting Username and Password to the input from the login page
                var user = new User
                {
                    Username = Entry_Username.Text,
                    Password = Entry_Pass.Text
                };
                // Check if input fields are empty and display error in LoginMessage label if a field, or both, are empty
                if (user.Username == "" || user.Password == "")
                {
                    LoginMessage.TextColor = Color.Red;
                    LoginMessage.Text = "Username or password field is empty";
                }
                // If all fields are filled continue and display "Loggin in! Please wait..." in the LoginMessage label on the loginpage
                else
                {
                    LoginMessage.TextColor = Color.SpringGreen;
                    LoginMessage.Text = "Logging in! Please wait...";
                    var result = await App.LoginService.Login(user);
                    var dbclear = new UserDatabase();
                    dbclear.Droptable();
                    // Check if you get an AccessToken from the local database. (One will be stored there with the user if login is successful)
                    // If an accesstoken exists in the local database, continue with the login
                    if (result.AccessToken != null)
                    {
                        var userDatabase = new UserDatabase();
                        userDatabase.AddUser(result);
                        Navigation.InsertPageBefore(new Index(), this); await Navigation.PopAsync(true);
                        LoginMessage.Text = "";
                        Entry_Pass.Text = "";
                    }
                    // If no accesstoken was found, the user wasn't logged in due to invalid login info and an error is returned to the loginpage
                    else
                    {
                        LoginMessage.TextColor = Color.Red;
                        LoginMessage.Text = "Invalid login information... Please try again!";
                    }
                }
            }
            // If user does not have an internetconnection, return this error
            else
            {
                LoginMessage.TextColor = Color.Red;
                LoginMessage.Text = "You're not connected to the internet!";
            }

        }


        //async Task LoginProcess_Clicked()
        //{
        //    LoginMessage.TextColor = Color.Green;
        //    LoginMessage.Text = "Logging in, please wait...";
        //    if (CheckNetwork.IsInternet())
        //    {
        //        var user = new User
        //        {
        //            Username = Entry_Username.Text,
        //            Password = Entry_Pass.Text
        //        };

        //        if (user.Username == null || user.Password == null)
        //        {
        //            LoginMessage.TextColor = Color.Red;
        //            LoginMessage.Text = "Email or password field is empty";
        //        }
        //        else
        //        {
        //            var result = await App.LoginService.Login(user);
        //            var dbclear = new UserDatabase();
        //            dbclear.Droptable();
        //            if (result.AccessToken != null)
        //            {
        //                var userDatabase = new UserDatabase();
        //                userDatabase.AddUser(result);

        //                var userdata = userDatabase.GetAllUsers();
        //                var displayname = userdata.First().Displayname;
        //                CurrentUser.Displayname = displayname;


        //                Entry_Username.Text = "";
        //                Entry_Pass.Text = "";
        //                LoginMessage.Text = "Logged in!";
        //                CurrentUser.IsUserLoggedIn = true;
        //                CurrentUser.Displayname = result.Displayname;
        //                Navigation.InsertPageBefore(new Index(), this); await Navigation.PopAsync(true);

        //            }
        //            else
        //            {
        //                LoginMessage.TextColor = Color.Red;
        //                LoginMessage.Text = "Invalid login information... please try again!";

        //            }
        //        }
        //    }
        //    else
        //    {
        //        LoginMessage.TextColor = Color.Red;
        //        LoginMessage.Text = "You're not connected to the internet!";
        //    }
        //}

        // Redirect to RegisterPage modal
        public async void ToRegister_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegisterPage());
        }
    }
}