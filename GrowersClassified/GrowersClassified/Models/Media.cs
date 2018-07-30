using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Plugin.Media.Abstractions;

namespace GrowersClassified.Models
{
    class Media
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Comment_Status { get; set; }
        public string Ping_Status { get; set; }
        public Byte[] Image { get; set; }
    }

}
