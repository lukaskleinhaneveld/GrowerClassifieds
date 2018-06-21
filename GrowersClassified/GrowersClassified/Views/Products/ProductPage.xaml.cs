﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using GrowersClassified.Models;
using Newtonsoft.Json.Linq;
using Xamarin.Forms.Internals;
using System.IO;
using System.Net;

namespace GrowersClassified.Views.Products
{
	public partial class ProductPage : ContentPage
	{
        public HttpClient _client = new HttpClient();
        public ListView ListView { get { return ProductList; } }
        public ProductPage ()
		{
			InitializeComponent();
            //LoadAllProducts();
            SetProducts();
        }

        async void SetProducts()
        {
            HttpClient _client = new HttpClient();
            var posts = await _client.GetAsync(Constants.GetPostsUrl);
            List<Product> products = new List<Product>
            {
                new Product ( "Lukas Klein Haneveld",   "Test Title",   "This is a test description",            "Test make",   "Test model",   "2018", "2000"),
                //new Product ( "Sannah Klein Haneveld",  "Test Title2",  "This is the 2nd test description.", "Test make 2", "Test model 2", "2018", "2000"),
                //new Product ( "Nel Romijn",             "Test Title3",  "This is the 3rd test description.", "Test make 3", "Test model 3", "2018", "2000"),
                //new Product ( "Maarten Klein Haneveld", "Test Title4",  "This is the 4th test description.", "Test make 4", "Test model 4", "2018", "2000"),
                //new Product ( "Vincent Klein Haneveld", "Test Title5",  "This is the 5th test description.", "Test make 5", "Test model 5", "2018", "2000"),
                //new Product ( "Ruben Klein Haneveld",   "Test Title6",  "This is the 6th test description.", "Test make 6", "Test model 6", "2018", "2000"),
                //new Product ( "Erika Klein Haneveld",   "Test Title7",  "This is the 7th test description.", "Test make 7", "Test model 7", "2018", "2000")
            };
            ListView.ItemsSource = products;
        }
    }
}