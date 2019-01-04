using GrowersClassified.Models;

using Xamarin.Forms;
using System.Net.Http;
using System;

namespace GrowersClassified.Views.Products
{
    public partial class CreateProduct : ContentPage
    {
        User user = new User();
        HttpClient _client = new HttpClient();
        public CreateProduct()
        {
            InitializeComponent();
        }

        public void CreateProduct_Clicked(object sender, EventArgs e)
        {
            Product product = new Product(
                user.Username, 
                Product_Description.Text, 
                Product_Title.Text, 
                Product_City.Text, 
                Product_State.Text, 
                Product_Make.Text, 
                Product_Model.Text, 
                Product_Year.Text, 
                Product_Price.Text
            );
            Console.WriteLine(product);
        }
    }
}