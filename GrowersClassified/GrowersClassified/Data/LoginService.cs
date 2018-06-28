using GrowersClassified.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GrowersClassified.Data
{
    public class LoginService
    {
        // Setting private variables that will be used more often. This makes it easier to use and easier to alter if needed
        private HttpClient _client;
        private string grant_type = "password";
        //private string contentType = "application/json";

        public LoginService()
        {
            // Creating new HttpClient and sets the maximum number of bytes to buffer when reading the response content 
            _client = new HttpClient { MaxResponseContentBufferSize = 256000 };
            // Specify request type
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public async Task<Token> Login(User user)
        {
            // Creating a list of data to send to the API to log a user in
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", grant_type),
                new KeyValuePair<string, string>("username", user.Username),
                new KeyValuePair<string, string>("password", user.Password)
            };
            // Encoding list so the API can use it
            var content = new FormUrlEncodedContent(postData);
            var response = await PostResponseLogin<Token>(Constants.UrlLogin, content);
            // Get current time
            var dt = DateTime.Today;
            response.ExpireDate = dt.AddSeconds(response.ExpireIn);
            return response;
        }

        public async Task<T> PostResponseLogin<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            // Sending encoded list to the API, API url defined in Constants.UrlLogin
            var response = await _client.PostAsync(Constants.UrlLogin, content);
            // Reading the result the API returned
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            // Deserializing the JSON object
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return responseObject;
        }
    }
}