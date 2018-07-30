using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GrowersClassified.Models
{
    // Specifying User info fields
    public class User
    {
        public int Id { get; set; }
        public int UserApp_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Nicename { get; set; }

    }
}
