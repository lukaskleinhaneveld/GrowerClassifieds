using System;
using Newtonsoft.Json;

namespace GrowersClassified.Models
{
    public class Token
    {
        public int Id { get; set; }
        [JsonProperty("access_token")] public string AccessToken { get; set; }
        [JsonProperty("email")] public string Email { get; set; }
        [JsonProperty("displayname")] public string Displayname { get; set; }
        public DateTime ExpireDate { get; set; }
        public double ExpireIn { get; set; }
    }
}