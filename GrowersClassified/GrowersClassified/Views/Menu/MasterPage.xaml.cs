using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrowersClassified.Data;
using GrowersClassified.Models;
using GrowersClassified.Views.Login;
using GrowersClassified.Views.Products;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowersClassified.Views.Menu
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listview; } }
        public List<MasterMenuItem> items;
        public MasterPage()
        {
            InitializeComponent();
            var userDatabase = new UserDatabase();
            var userdata = userDatabase.GetAllUsers();
            if (userdata.Count < 1)
            {
                BtnLoginProcess.IsVisible = true;
                LblUserName.IsVisible = false;
                BtnLogoutProcess.IsVisible = false;
            }
            //else 
            //{
            //    Console.WriteLine("***************************");
            //    Console.WriteLine("*** " + Displayname);
            //    Console.WriteLine("***************************");
            //    BtnLoginProcess.IsVisible = false;
            //    LblUserName.Text = "Welcome " + Displayname;
            //    LblUserName.IsVisible = true;
            //    BtnLogoutProcess.IsVisible = true;
            //}
            else
            {
                var Displayname = userdata.First().Displayname;
                BtnLoginProcess.IsVisible = false;
                LblUserName.Text = "Welcome " + Displayname;
                LblUserName.IsVisible = true;
                BtnLogoutProcess.IsVisible = true;
            }
            SetItems();
        }

        void SetItems()
        {
            items = new List<MasterMenuItem>
            {
                new MasterMenuItem("Home", "house.png", Color.WhiteSmoke, typeof(Index)),
                new MasterMenuItem("Products", "shoppingbag.png", Color.WhiteSmoke, typeof(ProductPage)),
                new MasterMenuItem("WebView", "icon.png", Color.WhiteSmoke, typeof(WebViewTest))
            };
            ListView.ItemsSource = items;

        }

        private async void ToLoginPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void BtnLogoutProcess_Clicked(object sender, EventArgs e)
        {
            var userDatabase = new UserDatabase();
            var id = userDatabase.GetAllUsers().First().Id;
            var userdata = userDatabase.DeleteUser(id);
            Navigation.InsertPageBefore(new Index(), this); await Navigation.PopAsync(true);
        }
    }
}