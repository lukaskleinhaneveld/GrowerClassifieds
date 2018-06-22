using System.Collections.Generic;
using Xamarin.Forms;
using GrowersClassified.Models;

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
            List<Product> products = new List<Product>
            {
                // Product(     Product_Author,           Product_Title,  Product_Description,                 Product_Make,  Product_Model,  Product_Year, Product_Price)
                //new Product (   "Lukas" + ",",   "Test Title" + ",",   "This is a test description" + ",",        "Test make" + ",",   "Test model" + ",",   "2018" + ",",       "2000"),
                //new Product (   "Lukas Klein Haneveld" + ",",   "Test Title2" + ",",   "This is a test description2" + ",",        "Test make2" + ",",   "Test model2" + ",",   "2018" + ",",       "2000"),
                //new Product (   "Lukas Klein Haneveld" + ",",   "Test Title3" + ",",   "This is a test description3" + ",",        "Test make3" + ",",   "Test model3" + ",",   "2018" + ",",       "2000"),
                //new Product (   "Lukas Klein Haneveld" + ",",   "Test Title4" + ",",   "This is a test description4" + ",",        "Test make4" + ",",   "Test model4" + ",",   "2018" + ",",       "2000"),
                //new Product (   "Lukas Klein Haneveld" + ",",   "Test Title5" + ",",   "This is a test description5" + ",",        "Test make5" + ",",   "Test model5" + ",",   "2018" + ",",       "2000"),
            };
            for (int i = 0; i < 10; i++)
            {
                user.Username = "Test user " + i;
                products.Add(new Product(user.Username + ",", "Test Title" + ",", "This is a test description" + ",", "Test make" + ",", "Test model" + ",", "2018" + ",", "2000"));
            }
            // Setting ListView items source to othe 'products' List
            ListView.ItemsSource = products;
        }
    }
}