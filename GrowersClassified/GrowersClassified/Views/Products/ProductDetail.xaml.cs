using GrowersClassified.Data;
using GrowersClassified.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowersClassified.Views.Products
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetail : ContentPage
	{
        public HttpClient _client = new HttpClient();
        public ActivityIndicator loadingWebView { get { return loadingWebView; } }

        public ProductDetail(object e)
        {// Check if user is connected to internet, if not, skip this
            if (CheckNetwork.IsInternet())
            {
                BindingContext = e;
            }
            else
            {
                ErrMessage.IsVisible = true;
                ErrMessage.TextColor = Color.Red;
                ErrMessage.Text = "You're not connected to the internet. Please make sure you are connected to use the app.";
            }
            InitializeComponent();
        }
    }
}