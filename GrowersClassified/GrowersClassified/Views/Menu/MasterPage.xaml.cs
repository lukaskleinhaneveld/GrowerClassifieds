using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string Displayname = CurrentUser.Displayame;
        public MasterPage()
        {
            InitializeComponent();
            if (!CurrentUser.IsUserLoggedIn)
            {
                BtnLoginProcess.IsVisible = true;
                LblUserName.IsVisible = false;
            }
            else
            {
                BtnLoginProcess.IsVisible = false;
                LblUserName.Text = Displayname;
                LblUserName.IsVisible = true;
            }
            SetItems();
        }

        void SetItems()
        {
            items = new List<MasterMenuItem>
            {
                new MasterMenuItem("Home", "house.png", Color.White, typeof(Index)),
                new MasterMenuItem("Products", "shoppingbag.png", Color.White, typeof(ProductPage))
            };
            ListView.ItemsSource = items;

        }

        private async void ToLoginPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }
}