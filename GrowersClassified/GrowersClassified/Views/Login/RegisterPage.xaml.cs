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
        public RegisterPage()
        {
            InitializeComponent();
        }

        // Redirect to LoginPage
        private async void ToLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), this);
            await Navigation.PopAsync();
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
                    Nicename = Entry_Nicename.Text,
                    Email = Entry_Email.Text,
                };

                if (Entry_Username.Text != null && Entry_Pass.Text != null && Entry_ConfirmPass.Text != null && Entry_Email.Text != null && Entry_Nicename.Text != null)
                {
                    if (Entry_Pass.Text == Entry_ConfirmPass.Text)
                    {
                        // Using hard coded admin to use it's bearer so we can register a user as this requires administrator access
                        var userRegister = new User
                        {
                            Username = "RegisterUser",
                            Password = "Bellp@rk2018"
                        };

                        // Login the administrator
                        var registerUser = await App.RestService.Login(userRegister);
                        // Setting bearer to the accesstoken we received from the admin (Can't hardcode the token as it refreshes every so often)
                        var bearer = registerUser.AccessToken;
                        Constants.CreateUserToken = bearer;


                        // Check if user already exist by searing for it's username
                        var doesUserExist = await App.RestService.DoesUserExist(user);
                        Console.WriteLine("doesUserExist: " + doesUserExist);
                        if (doesUserExist)
                        {
                            RegisterMessage.TextColor = Color.Red;
                            RegisterMessage.Text = "This username already exists. Please revise and try again.";
                        }
                        else
                        {
                            RegisterMessage.TextColor = Color.LightGreen;
                            RegisterMessage.Text = "Registration in progress...";
                            // Sending the user's input to the register logic
                            var registerResult = await App.RestService.Register(user);
                            Console.WriteLine("registerResult" + registerResult);

                            if (registerResult.AccessToken != null)
                            {
                                RegisterMessage.TextColor = Color.LightGreen;
                                RegisterMessage.Text = "Registration successfull. Logging you in.";
                                var loginResult = await App.RestService.Login(user);
                                Console.WriteLine("loginResult" + loginResult);

                            }
                        }

                    }
                    else
                    {
                        RegisterMessage.TextColor = Color.Red;
                        RegisterMessage.Text = "Password and Confirm password do not match. Please revise and try again.";
                    }
                }
                else
                {
                    RegisterMessage.TextColor = Color.Red;
                    RegisterMessage.Text = "Not all fields were filled. Please revise and try again.";
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
}