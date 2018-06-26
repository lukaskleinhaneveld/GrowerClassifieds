using System.Collections.Generic;
using Xamarin.Forms;
using GrowersClassified.Models;
using System;

namespace GrowersClassified.Views.Products
{
	public partial class ProductPage : ContentPage
	{
        // Setting ListView to the x:Name of the listview in the xaml page
        public ListView ListView { get { return ProductList; } }
        public User user = new User();
        public ProductPage ()
		{
			InitializeComponent();
            // Calling 'SetProducts' to populate the page
            SetProducts();
        }

        void SetProducts()
        {
            // Creating list 'products'
            List<Product> products = new List<Product>{};
            for (int i = 0; i < 10; i++)
            {
                user.Username = "Test user " + i;
                products.Add(new Product(user.Username,         // Username
                    "Test Title",                               // Title
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",         // Description
                    "Test City" + ",",                          // City
                    "Test State" + ",",                         // State
                    "Test make" + ",",                          // Make
                    "Test model" + ",",                         // Model
                    "2018" + ",",                               // Year
                    "CAD $" + "2000"));                         //Price
            }
            // Setting ListView items source to othe 'products' List
            ListView.ItemsSource = products;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            ((ListView)sender).SelectedItem = null;

        }
    }
}