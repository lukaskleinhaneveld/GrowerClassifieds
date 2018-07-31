using GrowersClassified.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace GrowersClassified.Data
{
    public class RestService
    {
        #region RestService Setup
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
        #endregion

        #region Login System
        // Login System
        public async Task<Token> Login(User LoginUser)
        {
            Console.WriteLine($"LoginUser {LoginUser}");
            // Setting url of which to send the request to
            string weburl = Constants.UrlLogin;
            // Creating a list of data to send to the API to log a user in
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", grant_type),
                new KeyValuePair<string, string>("username", LoginUser.Username),
                new KeyValuePair<string, string>("password", LoginUser.Password)
            };
            // Encoding list so the API can use it
            var content = new FormUrlEncodedContent(postData);
            var response = await PostResponseLogin<Token>(weburl, content);
           // Get current time
            var dt = DateTime.Today;
            response.ExpireDate = dt.AddSeconds(response.ExpireIn);
            return response;
        }

        public async Task<T> PostResponseLogin<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            // Sending encoded list to the API, API url defined in Constants.UrlLogin
            var response = await _client.PostAsync(weburl, content);
            // Reading the result the API returned
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            // Deserializing the JSON object
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            // Add this ID to the user
            return responseObject;
        }
        #endregion

        #region Register System
        // Register System
        public async Task<Token> Register(User RegisterUser)
        {
            Console.WriteLine($"RegisterUser {RegisterUser}");
            // Setting url of which to send the request to
            string weburl = Constants.UrlRegister;
            // Creating a list of data to send to the API to log a user in
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", RegisterUser.Username),
                new KeyValuePair<string, string>("password", RegisterUser.Password),
                new KeyValuePair<string, string>("name", RegisterUser.Nicename),
                new KeyValuePair<string, string>("email", RegisterUser.Email)
            };
            
            // Encoding list so the API can use it
            var content = new FormUrlEncodedContent(postData);
            // Encoding list so the API can use it
            var response = await PostResponseRegister<Token>(weburl, content);
            // Get current time
            var dt = DateTime.Today;
            response.ExpireDate = dt.AddSeconds(response.ExpireIn);
            return response;
        }

        public async Task<T> PostResponseRegister<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            // Adding Bearer with administrator accesstoken
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Constants.CreateUserToken);
            Console.WriteLine($"_client.DefaultRequestHeaders.Authorization: {_client.DefaultRequestHeaders.Authorization}");
            // Sending register request
            var response = await _client.PostAsync(weburl, content);
            var JsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(JsonResult);
            return responseObject;
        }
        #endregion

        #region Post Response
        public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            string ContentType = "application/json";
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.AccessToken);
            var result = await _client.PostAsync(weburl, new StringContent(jsonstring, Encoding.UTF8, ContentType));
            var JsonResult = result.Content.ReadAsStringAsync().Result;
            var contentResp = JsonConvert.DeserializeObject<T>(JsonResult);
            return contentResp;
        }
        #endregion

        #region GetResponse
        // Gets all responses
        public async Task<T> GetResponse<T>(string weburl) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.AccessToken);
            var response = await _client.GetAsync(weburl);
            var JsonResult = response.Content.ReadAsStringAsync().Result;
            var ContentResp = JsonConvert.DeserializeObject<T>(JsonResult);
            return ContentResp;
        }
        #endregion

        #region Logout
        public void Logout()
        {
            UserDatabase uDB = new UserDatabase();
            var loggingOut = uDB.LogoutUser();
        }
        #endregion

        #region Check if user exists
        public async Task<bool> DoesUserExist(User user)
        {
            var param = user.Username;
            string weburl = "http://www.growerclassifieds.com/wp-json/wp/v2/users?search=" + param;


            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Adding admin token to request since this has to be an authorized request
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.CreateUserToken);
            var response = await _client.GetAsync(weburl);
            var result = response.Content.ReadAsStringAsync().Result;

            if (result.Length > 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}