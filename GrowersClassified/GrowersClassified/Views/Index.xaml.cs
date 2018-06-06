using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
            await Navigation.PushAsync(new CreateProduct());
        }
    }
}