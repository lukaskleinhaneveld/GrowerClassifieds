using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GrowersClassified.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public User() { }
        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public bool CheckInformation()
        {
            
            if (!this.Username.Equals("") || !this.Username.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
