using System.Collections.Generic;
using Xamarin.Forms;
using GrowersClassified.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json.Linq;

namespace GrowersClassified.Views.Products
{
	public partial class ProductPage : ContentPage
	{
        HttpClient _client = new HttpClient();
        public ActivityIndicator indicator { get { return loadingProducts; } }
        // Setting ListView to the x:Name of the listview in the xaml page
        public ListView ListView { get { return ProductList; } }
        public WebView webView { get { return webView; } }
        // Creating list 'products'
        public List<Product> products = new List<Product> { };

        public User user = new User();
        public string htmlOutput;
        public ProductPage ()
        {
            InitializeComponent();
            HtmlToContent();
            SetProducts();
        }

        void SetProducts()
        {
            indicator.IsVisible = true;
            // Set product list with new products
            for (int i = 0; i < 10; i++)
            {
                user.Username = "Test user " + i;
                products.Add(new Product(user.Username,   // Username
                    "Test Title",                         // Title
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",         // Description
                    "Test City",                          // City
                    "Test State",                         // State
                    "Test make",                          // Make
                    "Test model",                         // Model
                    "2018",                               // Year
                    "CAD $" + "2000"                      //Price
                ));                         
            }
            
            // Setting ListView items source to othe 'products' List
            ListView.ItemsSource = products;
        }

        async void HtmlToContent()
        {

            var response = await _client.GetAsync(Constants.GetPostsUrl);
            var content = await response.Content.ReadAsStringAsync();
            var json = response.Content.ReadAsStringAsync().Result;

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

                htmlOutput = o["content"]["rendered"].ToString();
                var htmlSource = new HtmlWebViewSource { Html = '"' + htmlOutput + '"' };
                //if (htmlSource != null)
                //    webView.Source = htmlSource;

                Console.WriteLine("Html Output: " + htmlOutput);

                products.Add(new Product(
                    "Freek",
                    "Ur mom",
                    htmlOutput,
                    "Test City",
                    "Test State",
                    "Test make",
                    "Test model",
                    "2018",
                    "CAD $" + "2000"
                ));

                string textTotal = "";
                //Console.WriteLine("Initiate textTotal: " + textTotal);

                string oldText = textTotal;
                //Console.WriteLine("oldText: " + oldText);

                string newText = htmlOutput;
                //Console.WriteLine("newText: " + newText);

                textTotal = oldText + newText;
                Console.WriteLine("textTotal: " + textTotal);
            }
            indicator.IsVisible = false;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }
            await Navigation.PushAsync(new ProductDetail());
            //await DisplayAlert("Item Selected", htmlOutput, "Ok");
            ((ListView)sender).SelectedItem = null;
        }
    }
}