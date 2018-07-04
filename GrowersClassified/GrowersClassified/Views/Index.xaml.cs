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

        private async void ToCreateProduct(object sender, EventArgs e)
        {
            var userDatabase = new UserDatabase();
            var userdata = userDatabase.GetAllUsers();
            if(userdata.Count == 1)
            {
                Navigation.InsertPageBefore(new CreateProduct(), this);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Error", "You must be logged in to create an ad.", "Ok");
                Navigation.InsertPageBefore(new LoginPage(), this);
                await Navigation.PopAsync();
            }
        }
    }
}