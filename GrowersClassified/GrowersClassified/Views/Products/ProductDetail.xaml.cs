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
        public WebView webView = new WebView();

        public ProductDetail()
        {
            InitializeComponent();
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
            loadingWebView.IsVisible = true;
        }

        void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            loadingWebView.IsVisible = false;
        }
    }
}