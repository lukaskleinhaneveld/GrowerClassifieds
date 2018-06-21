using System;
using Newtonsoft.Json;
using SQLite;

namespace GrowersClassified.Models
{
    //[Table("UserData")]
    //public class Token
    //{
    //    [PrimaryKey, AutoIncrement, NotNull]
    //    public int Id { get; set; }
    //    [Unique]
    //    [JsonProperty("access_token")]
    //    public string AccessToken { get; set; }
    //    [JsonProperty("firstname")] public string Firstname { get; set; }
    //    [JsonProperty("lastname")] public string Lastname { get; set; }
    //    [JsonProperty("displayname")] public string Displayname { get; set; }
    //    [JsonProperty("email")] public string Email { get; set; }
    //    [JsonProperty("city")] public string City { get; set; }
    //    [JsonProperty("state")] public string State { get; set; }
    //    [JsonProperty("country")] public string Country { get; set; }
    //    public string ErrorDescription { get; set; }
    //    public DateTime ExpireDate { get; set; }
    //    public double ExpireIn { get; set; }
    //}


    [Table("UserData")]
    public class Token
    {
        [PrimaryKey, AutoIncrement, NotNull]
        public int Id { get; set; }
        [Unique]
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("user_login")] public string Username { get; set; }
        [JsonProperty("user_pass")] public string Password { get; set; }
        [JsonProperty("user_nickname")] public string Nickname { get; set; }
        [JsonProperty("user_email")] public string Email { get; set; }
        [JsonProperty("user_url")] public string Website { get; set; }
        [JsonProperty("user_registered")] public string RegisteredOn { get; set; }
        [JsonProperty("user_activation_key")] public string ActivationKey { get; set; }
        [JsonProperty("user_status")] public string Status { get; set; }
        [JsonProperty("user_displayname")] public string Displayname { get; set; }
        public string ErrorDescription { get; set; }
        public DateTime ExpireDate { get; set; }
        public double ExpireIn { get; set; }
    }

}