using System;
using System.Collections.Generic;
using System.Text;

namespace GrowersClassified.Models
{
    class Globals
    {
        public class AppUserData
        {
            public int User_Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Displayname { get; set; }
            public string Email { get; set; }

            public AppUserData(int _User_Id, string _Username, string _Password, string _Displayname, string _Email)
            {
                this.User_Id = _User_Id;
                this.Username = _Username;
                this.Password = _Password;
                this.Displayname = _Displayname;
                this.Email = _Email;
            }
        }
    }
}
