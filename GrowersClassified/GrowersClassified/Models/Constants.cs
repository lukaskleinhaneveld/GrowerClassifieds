using Xamarin.Forms;

namespace GrowersClassified.Models
{
    // Setting various links and other globally reused variables
    public class Constants
    {
        public static string BaseUrl = "http://www.growerclassifieds.com/wp-json/";
        public static string UrlLogin = "http://www.growerclassifieds.com/wp-json/jwt-auth/v1/token";
        public static string UrlRegister = "http://www.growerclassifieds.com/wp-json/wp/v2/users";
        public static string GetPostsUrl = "http://www.growerclassifieds.com/wp-json/wp/v2/posts";
    }
}