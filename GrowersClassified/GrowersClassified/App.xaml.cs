using System.Collections.Generic;
using System.Linq;
using System.Text;
using GrowersClassified.Data;
using GrowersClassified.Models;
using GrowersClassified.Views.Menu;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Push;
using System;
using System.Threading.Tasks;

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

        protected override async void OnStart()
        {
            #region Update user to refresh auth token
            UserDatabase uDB = new UserDatabase();
            var AppUserData = uDB.GetAllUsers();

            // Check if a user already exists:
            if (AppUserData.Count != 0)
            {
                User AppUser = new User()
                {
                    Username = AppUserData[0].Username,
                    Password = AppUserData[0].Password,
                };
                
                var result = await RestService.Login(AppUser);
                //result.Username = AppUserData[0].Username;
                //result.Password = AppUserData[0].Password;
                //AppUserData[0].WP_Id = result.WP_Id;
                //AppUserData[0].Nickname = result.Displayname;
                //AppUserData[0].Email = result.Email;
                uDB.UpdateUser(result);   
            }
            #endregion

            #region AppCenter init
            AppCenter.Start(
                "ios=cadde90a-e7d4-4488-b4df-4ee5f3fbc174;" +
                "android=83ece3d7-61ae-4edb-8279-6d8ce9536966",
                typeof(Analytics), typeof(Crashes), typeof(Push)
            );
            #endregion
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
