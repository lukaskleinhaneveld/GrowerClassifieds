using GrowersClassified.Data;
using GrowersClassified.Models;
using GrowersClassified.Views.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowersClassified.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public ActivityIndicator indicator { get { return registering; } }
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
            RegisterMessage.TextColor = Color.LightGreen;
            RegisterMessage.Text = "Registration in progress...";
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
                    indicator.IsVisible = true;
                    if (Entry_Pass.Text == Entry_ConfirmPass.Text)
                    {

                        Console.WriteLine("**********");
                        Console.WriteLine("Entry_Pass: " + Entry_Pass.Text + " Entry_ConfirmPass: " + Entry_ConfirmPass.Text);
                        Console.WriteLine("**********");
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

                        if (user.Username.Length > 5)
                        {
                            if (Regex.Match(user.Username, @"^[a-zA-Z]+$").Success)
                            {
                                if (user.Nicename.Length > 5) 
                                {
                                    if (Regex.Match(user.Nicename, @"^[a-zA-Z]+$").Success)
                                    {
                                        // Check if user already exist by searing for it's username
                                        var doesUserExist = await App.RestService.DoesUserExist(user);
                                        if (doesUserExist)
                                        {
                                            RegisterMessage.TextColor = Color.Red;
                                            RegisterMessage.Text = "This username already exists. Please revise and try again.";
                                        }
                                        else
                                        {
                                            var userEmail = user.Email;
                                            var email = userEmail.ToLower();

                                            var emailPattern = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";
                                            if (Regex.Match(email, emailPattern).Success)
                                            {
                                                // Sending the user's input to the register logic
                                                var registerResult = await App.RestService.Register(user);
                                                if (registerResult.Id != 0)
                                                {
                                                    RegisterMessage.TextColor = Color.LightGreen;
                                                    RegisterMessage.Text = "Registration successfull. Logging you in.";
                                                    var loginResult = await App.RestService.Login(user);

                                                    var userDatabase = new UserDatabase();
                                                    userDatabase.Droptable();
                                                    userDatabase.AddUser(loginResult);

                                                    await Task.Delay(1000);
                                                    Navigation.InsertPageBefore(new Index(), this);
                                                    await Navigation.PopAsync();
                                                }
                                            }
                                            else
                                            {
                                                RegisterMessage.TextColor = Color.Red;
                                                RegisterMessage.Text = "Email is not in correct format. Please revise and try agian.";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        RegisterMessage.TextColor = Color.Red;
                                        RegisterMessage.Text = "Full name must only contain letters. Please revise and try again.";
                                    }
                                }
                                else
                                {
                                    RegisterMessage.TextColor = Color.Red;
                                    RegisterMessage.Text = "Full name must be at least 6 characters long. Please revise and try again.";
                                }
                            }
                            else
                            {
                                RegisterMessage.TextColor = Color.Red;
                                RegisterMessage.Text = "Username must only contain letters. Please revise and try again.";
                            }
                            }
                        else
                        {
                            RegisterMessage.TextColor = Color.Red;
                            RegisterMessage.Text = "Username must be at least 6 characters long. Please revise and try again.";

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
            indicator.IsVisible = false;
        }
    }
}