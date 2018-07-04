using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrowersClassified.Views;
using GrowersClassified.Data;
using GrowersClassified.Views.Menu;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;

namespace GrowersClassified
{
    public partial class App : Application
    {
        static TokenDbController _tokenDatabase;
        private static RestService _restServiceLogin;

        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage(new MasterDetail());
        }

        protected override void OnStart()
        {
            AppCenter.Start(
                "ios=cadde90a-e7d4-4488-b4df-4ee5f3fbc174;" +
                "android=83ece3d7-61ae-4edb-8279-6d8ce9536966",
                typeof(Analytics), typeof(Crashes), typeof(Push)
            );
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

        public static RestService RestService
        {
            get
            {
                if (_restServiceLogin == null)
                {
                    _restServiceLogin = new RestService();
                }
                return _restServiceLogin;
            }
        }
    }
}
