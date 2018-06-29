using GrowersClassified.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace GrowersClassified.Data
{
    public class RestService
    {
        // Setting private variables that will be used more often. This makes it easier to use and easier to alter if needed
        private HttpClient _client;
        private string grant_type = "password";
        //private string contentType = "application/json";

        public RestService()
        {
            // Creating new HttpClient and sets the maximum number of bytes to buffer when reading the response content 
            _client = new HttpClient { MaxResponseContentBufferSize = 256000 };
            // Specify request type
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public async Task<Token> Login(User user)
        {
            // Creating a list of data to send to the API to log a user in
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));
            // Encoding list so the API can use it
            var content = new FormUrlEncodedContent(postData);
            var response = await PostResponseLogin<Token>(Constants.UrlLogin, content);
            // Get current time
            var dt = DateTime.Today;
            //response.ExpireDate = dt.AddSeconds(response.ExpireIn);
            Console.WriteLine("Dt: " + dt);
            return response;
        }

        public async Task<T> PostResponseLogin<T>(string webUrl, FormUrlEncodedContent content) where T : class
        {
            // Sending encoded list to the API, API url defined in Constants.UrlLogin
            var response = await _client.PostAsync(Constants.UrlLogin, content);
            // Reading the result the API returned
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            // Deserializing the JSON object
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            Console.WriteLine(responseObject);
            return responseObject;
        }

        public async Task<T> PostResponse<T>(string webUrl, string jsonstring) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            string ContentType = "application/json";
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.AccessToken);
            try
            {
                var Result = await _client.PostAsync(Constants.UrlLogin, new StringContent(jsonstring, Encoding.UTF8, ContentType));
                if(Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = Result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return ContentResp;
                    }
                    catch { return null; }
                }
            }
            catch { return null; }
            return null;
        }

        public async Task<T> GetResponse<T>(string webUrl) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.AccessToken);
            try
            {
                var response = await _client.GetAsync(Constants.UrlLogin);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return ContentResp;
                    }
                    catch { return null; }
                }
            }
            catch { return null; }
            return null;
        }
    }
}