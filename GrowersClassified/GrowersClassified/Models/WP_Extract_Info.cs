using System;
using System.Collections.Generic;
using System.Text;

namespace GrowersClassified.Models
{
    public class WP_Extract_Info
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Date_gmt { get; set; }
        public string Guid { get; set; }
        public string Modified { get; set; }
        public string Modified_gmt { get; set; }
        public string Slug { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }
        public string Excerpt { get; set; }
        public string Author { get; set; }
        public string Categories { get; set; }
        public string Tags { get; set; }
    }
}
