using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GrowersClassified.Data;
using GrowersClassified.Models;
using GrowersClassified.Views.Login;
using GrowersClassified.Views.Products;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowersClassified
{
    public partial class Index : ContentPage
    {
        public Index()
        {
            InitializeComponent();
        }
        async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var imageSender = (Xamarin.Forms.Image)sender;
            Navigation.InsertPageBefore(new ProductPage(), this);
            await Navigation.PopAsync();
        }

        private async void ToCreateProduct(object sender, EventArgs e)
        {
            if (CheckNetwork.IsInternet())
            {
                var userDatabase = new UserDatabase();
                var userdata = userDatabase.GetAllUsers();
                if (userdata.Count == 1)
                {
                    await Navigation.PushAsync(new CreateProduct());
                }
                else
                {
                    await DisplayAlert("Error", "You must be logged in to create an ad.", "Ok");
                    await Navigation.PushAsync(new LoginPage());
                }
            }
            else
            {
                ErrMessage.IsVisible = true;
                ErrMessage.TextColor = Color.Red;
                ErrMessage.Text = "You're not connected to the internet. Please make sure you are connected to use the app.";
            }
        }
    }
}