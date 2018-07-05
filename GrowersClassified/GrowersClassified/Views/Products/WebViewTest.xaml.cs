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
	public partial class WebViewTest : ContentPage
    {
        public HttpClient _client = new HttpClient();
        public ActivityIndicator indicator { get { return loadingWebView; } }

        public WebViewTest ()
        {
            InitializeComponent ();
            CreateProduct();
        }

        async void CreateProduct()
        {
            indicator.IsVisible = true;
            var response = await _client.GetAsync(Constants.GetPostsUrl);
            var content = await response.Content.ReadAsStringAsync();
            var json = response.Content.ReadAsStringAsync().Result;
            string textTotal = "";

            JArray a = JArray.Parse(json);
            foreach (JObject o in a.Children<JObject>())
            {
                foreach (JProperty p in o.Properties())
                {
                    // Getting JSON Name Property
                    var name = p.Name;

                    // Getting JSON Value Property
                    var value = (object)p.Value;
                }

                var htmlOutput = o["content"]["rendered"].ToString();

                string oldText = textTotal;
                string newText = htmlOutput;
                textTotal = oldText + newText;
            }

            var htmlSource = new HtmlWebViewSource { Html = textTotal };
            if (textTotal != null)
                webView.Source = htmlSource;
            indicator.IsVisible = false;
        }


        private void backClicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private void forwardClicked(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        void webOnNavigating(object sender, WebNavigatingEventArgs e)
        {
            indicator.IsVisible = true;
        }

        void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            indicator.IsVisible = false;
        }
    }
}