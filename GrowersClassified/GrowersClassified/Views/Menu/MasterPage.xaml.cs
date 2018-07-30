using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrowersClassified.Data;
using GrowersClassified.Models;
using GrowersClassified.Views.Login;
using GrowersClassified.Views.Products;
using GrowersClassified.Views.Account;
using GrowersClassified.Views.Contact;
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
            SetItems();
        }

        void SetItems()
        {
            items = new List<MasterMenuItem>
            {
                new MasterMenuItem("Home", "house.png", Color.WhiteSmoke, typeof(Index)),
                new MasterMenuItem("Products", "shoppingbag.png", Color.WhiteSmoke, typeof(ProductPage)),
                new MasterMenuItem("Account", "icon.png", Color.WhiteSmoke, typeof(AccountPage)),
                new MasterMenuItem("WebView", "icon.png", Color.WhiteSmoke, typeof(WebViewTest)),
                new MasterMenuItem("Contact", "icon.png", Color.WhiteSmoke, typeof(ContactPage)),
                new MasterMenuItem("Page1", "icon.png", Color.WhiteSmoke, typeof(Page1)),
            };
            ListView.ItemsSource = items;
        }
    }
}