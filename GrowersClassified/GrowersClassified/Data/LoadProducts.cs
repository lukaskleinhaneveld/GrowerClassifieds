using GrowersClassified.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GrowersClassified.Data
{
    class LoadProducts
    {
        readonly HttpClient _client;

        public async Task<Token> GetAllPosts()
        {
            _client = new HttpClient { MaxResponseContentBufferSize = 256000 };
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            User user = new User("Lukas", "Luk@s87761");
            var content = JsonConvert.SerializeObject(user);
            Console.WriteLine(content);
            await _client.PostAsync(Constants.BaseUrl + "jwt-auth/v1/token", new StringContent(content));
            Console.WriteLine(content);
        }
    }
}
