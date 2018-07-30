using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GrowersClassified.Models
{
    public class BlogPost
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public DateTime DateCreated { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("excerpt")]
        public string Excerpt { get; set; }

        [JsonProperty("categories")]
        public Dictionary<string, object> Categories { get; set; }

        public List<string> CategoryNames
        {
            get
            {
                return Categories.Select(x => x.Key).ToList();
            }
        }
    }
}
