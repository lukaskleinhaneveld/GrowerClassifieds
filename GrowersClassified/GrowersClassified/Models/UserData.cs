using System;
using Newtonsoft.Json;
using SQLite;

namespace GrowersClassified.Models
{
    [Table("UserData")]
    public class UserData
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        [Unique]
        [JsonProperty("access_token")] public string AccessToken { get; set; }
        [JsonProperty("firstname")] public string Firstname { get; set; }
        [JsonProperty("lastname")] public string Lastname { get; set; }
        [JsonProperty("displayname")] public string Displayname { get; set; }
        [JsonProperty("email")] public string Email { get; set; }
        [JsonProperty("city")] public string City { get; set; }
        [JsonProperty("state")] public string State { get; set; }
        [JsonProperty("country")] public string Country { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime ExpireDate { get; set; }
        public double ExpireIn { get; set; }
    }
}
