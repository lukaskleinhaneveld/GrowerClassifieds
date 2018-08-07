using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http.Headers;
using System.Globalization;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft;
using System.Net.Http;
using Xamarin.Forms;

namespace GrowersClassified.Models
{
    public class GetProducts
    {
        public HttpClient _client = new HttpClient();
        public List<Product> Products = new List<Product>();

        public async void LoadAllProducts(ListView ListView, ActivityIndicator LoadingProducts, Label LoadingProductsLbl)
        {
            LoadingProducts.IsVisible = true;
            LoadingProductsLbl.IsVisible = true;
            LoadingProductsLbl.Text = "Loading...";
            try
            {
                var userAuth = new User
                {
                    Username = "AuthorizedUserForApp",
                    Password = "Bellp@rk2018"
                };
                // Login the administrator
                var authUser = await App.RestService.Login(userAuth);

                // Setting bearer to the accesstoken we received from the admin (Can't hardcode the token as it refreshes every so often)
                var bearer = authUser.AccessToken;
                Constants.CreateUserToken = bearer;
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer);
                var response = _client.GetAsync(Constants.PostsUrl);
                string jsonResponse = response.Result.Content.ReadAsStringAsync().Result;
                var json = SanitizeReceivedJson(jsonResponse);

                JArray array = JArray.Parse(json);
                foreach (object item in array)
                {
                    try
                    {
                        var ser = JsonConvert.SerializeObject(item);
                        var res = JToken.Parse(ser);
                        var product = JsonConvert.DeserializeObject<Product>(ser);
                        product.short_description = Sanitizer(product.short_description);
                        product.regular_price = string.Format("{0:C}", product.regular_price);
                        Products.Add(product);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception caught: {ex}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex}");
            }
            ListView.ItemsSource = Products;
            LoadingProducts.IsVisible = false;
            LoadingProductsLbl.IsVisible = false;
        }
        private string SanitizeReceivedJson(string uglyJson)
        {
            var sb = new StringBuilder(uglyJson);
            sb.Replace("\\\t", "\t");
            sb.Replace("\\\n", "\n");
            sb.Replace("\\\r", "\r");
            sb.Replace("<p>", "");
            sb.Replace("<\\/p>", "");
            Console.WriteLine($"String: {sb}");
            return sb.ToString();
        }

        private string Sanitizer(string short_description)
        {
            var sb = new StringBuilder(short_description);
            sb.Replace(",", System.Environment.NewLine);
            return sb.ToString();
        }
    }
}
