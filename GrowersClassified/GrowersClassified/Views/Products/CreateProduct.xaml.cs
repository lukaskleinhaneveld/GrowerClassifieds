using GrowersClassified.Models;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

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

        //private void CreateProductProcess_Clicked()
        //{
        //    new Product
        //    {
        //        Product_Title = Product_Title.Text,
        //        Product_Description = Product_Description.Text,
        //        Product_Model = Product_Model.Text,
        //        Product_Make = Product_Make.Text,
        //        Product_Year = Product_Year.Text,
        //        Product_Price = Product_Make.Text,
        //        Product_Author = user.Displayname;
        //    };
        //}
    }
}