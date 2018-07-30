using System;
using Newtonsoft.Json;
using SQLite;

namespace GrowersClassified.Models
{
    // Selecting table and assigning variables to json properties (in database)
    [Table("UserData")]
    public class Token
    {
        [PrimaryKey, AutoIncrement, NotNull]
        [JsonProperty("id")] public int UserApp_Id { get; set; }
        [Unique]
        public int Id { get; set; }
        [JsonProperty("token")]public string AccessToken { get; set; }
        [JsonProperty("user_login")] public string Username { get; set; }
        public string Password { get; set; }
        [JsonProperty("user_nicename")] public string Nickname { get; set; }
        [JsonProperty("user_email")] public string Email { get; set; }
        [JsonProperty("user_url")] public string Website { get; set; }
        [JsonProperty("user_registered")] public string RegisteredOn { get; set; }
        [JsonProperty("user_activation_key")] public string ActivationKey { get; set; }
        [JsonProperty("user_status")] public string Status { get; set; }
        [JsonProperty("user_display_name")] public string Displayname { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime ExpireDate { get; set; }
        public double ExpireIn { get; set; }
    }

}