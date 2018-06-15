﻿using GrowersClassified.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GrowersClassified;

namespace GrowersClassified.Data
{
    public class LoginService
    {
        readonly HttpClient _client;
        private string grant_type = "password";

        public LoginService()
        {
            _client = new HttpClient { MaxResponseContentBufferSize = 256000 };
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public async Task<Token> Login(User user)
        {
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", grant_type),
                new KeyValuePair<string, string>("email", user.Email),
                new KeyValuePair<string, string>("password", user.Password)
            };
            var content = new FormUrlEncodedContent(postData);
            var response = await PostResponseLogin<Token>(Constants.UrlLogin, content);
            var dt = DateTime.Today;
            response.ExpireDate = dt.AddSeconds(response.ExpireIn);
            return response;
        }

        public async Task<T> PostResponseLogin<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            var response = await _client.PostAsync(Constants.UrlLogin, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return responseObject;
        }

        public async Task<T> PostResponse<T>(string weburl, string jsonstring) where T : class
        {
            var token = App.TokenDatabase.GetToken();
            string contentType = "application/json";
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
            try
            {
                var result = await _client.PostAsync(Constants.UrlLogin, new StringContent(jsonstring, Encoding.UTF8, contentType));
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonresult = result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(jsonresult);
                        return contentResp;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        public async Task<T> GetResponse<T>(string weburl) where T : class
        {
            var token = App.TokenDatabase.GetToken();
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
            try
            {
                var response = await _client.GetAsync(weburl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonresult = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine("JsonResult:" + jsonresult);
                    try
                    {
                        var contentResp = JsonConvert.DeserializeObject<T>(jsonresult);
                        return contentResp;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

    }
}