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
        public ActivityIndicator indicator { get { return loadingWebView; } }

        public ProductDetail()
        {
            InitializeComponent();
            CreateProduct();
        }

        async void CreateProduct()
        {
            indicator.IsVisible = true;
            var response = await _client.GetAsync(Constants.GetPostsUrl);
            var content = await response.Content.ReadAsStringAsync();
            var json = response.Content.ReadAsStringAsync().Result;
            string textTotal = "";

            JArray array = JArray.Parse(json);
            foreach (JObject obj in array.Children<JObject>())
            {
                foreach (JProperty prop in obj.Properties())
                {
                    // Getting JSON Name Property
                    var name = prop.Name;

                    // Getting JSON Value Property
                    var value = (object)prop.Value;
                }

                var contentOutput = obj["content"]["rendered"].ToString();
                var excerptOutput = obj["excerpt"]["rendered"].ToString();
                var titleOutput   = obj["title"]["rendered"].ToString();

                string oldText = textTotal;
                string newText = excerptOutput;
                textTotal = oldText + newText;
                Console.WriteLine("textTotal: " + textTotal);
            }

            var htmlSource = new HtmlWebViewSource { Html = textTotal };
            if (textTotal != null)
                webView.Source = htmlSource;
            indicator.IsVisible = false;
        }

        //private void backClicked(object sender, EventArgs e)
        //{
        //    // Check to see if there is anywhere to go back to
        //    if (webView.CanGoBack)
        //    {
        //        webView.GoBack();
        //    }
        //    else
        //    { // If not, leave the view
        //        Navigation.PopAsync();
        //    }
        //    Console.WriteLine(webView.CanGoBack);
        //}

        //private void forwardClicked(object sender, EventArgs e)
        //{
        //    if (webView.CanGoForward)
        //    {
        //        webView.GoForward();

        //    }
        //    Console.WriteLine(webView.CanGoForward);
        //}
    }
}