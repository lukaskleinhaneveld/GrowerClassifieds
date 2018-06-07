using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrowersClassified.Views;
using GrowersClassified.Data;
using GrowersClassified.Views.Menu;
using Xamarin.Forms;

namespace GrowersClassified
{
    public partial class App : Application
    {
        static TokenDbController _tokenDatabase;
        private static LoginService _restServiceLogin;

        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage(new MasterDetail());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public static TokenDbController TokenDatabase
        {
            get
            {
                if (_tokenDatabase == null)
                {
                    _tokenDatabase = new TokenDbController();
                }

                return _tokenDatabase;
            }
        }

        public static LoginService LoginService
        {
            get
            {
                if (_restServiceLogin == null)
                {
                    _restServiceLogin = new LoginService();
                }
                return _restServiceLogin;
            }
        }
    }
}
