using System;
using Xamarin.Forms;

namespace GrowersClassified.Models
{
    // Setting various links and other globally reused variables
    public class Constants
    {
        #region URLs
        public static string BaseUrl = "http://www.growerclassifieds.com/wp-json/";
        public static string UrlLogin = "http://www.growerclassifieds.com/wp-json/jwt-auth/v1/token";/*POST*/
        public static string UrlRegister = "http://www.growerclassifieds.com/wp-json/wp/v2/users";/*POST*/
        public static string PostsUrl = "http://www.growerclassifieds.com/wp-json/wc/v2/products";/*GET*/
        public static string PostImage = "http://www.growerclassifieds.com/wp-json/wp/v2/media";/*POST*/
        public static string CreateUserToken = "";/*Used to access outside loop*/
        #endregion

        #region FTP Info
        DateTime date = DateTime.Now;
        public static string CurrentYear = DateTime.Now.Year.ToString();
        public static string CurrentMonth = DateTime.Now.Month.ToString("d2");
        public static string CurrentDay = DateTime.Now.Day.ToString("d2");

        public static string FTP_URL = "ftp://ftp.growerclassifieds.com/";
        public static string FTP_Username = "growclass7";
        public static string FTP_UserPassword = "avzw5a8Lodi*";
        public static string FTP_Location = "/public_html/wp-content/uploads/" + CurrentYear + "/" + CurrentMonth;
        #endregion
    }
}