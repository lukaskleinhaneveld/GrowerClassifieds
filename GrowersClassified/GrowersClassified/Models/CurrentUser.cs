using System;
using System.Collections.Generic;
using System.Text;

namespace GrowersClassified.Models
{
    class CurrentUser
    {
        private static bool _IsUserLoggedIn = false;
        public static bool IsUserLoggedIn
        {
            get { return _IsUserLoggedIn; }
            set { _IsUserLoggedIn = value; }
        }


        private static string _Displayname = "";
        public static string Displayame
        {
            get { return _Displayname; }
            set { _Displayname = value; }
        }
    }
}
