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
        Product product = new Product();
        public CreateProduct()
        {
            InitializeComponent();
        }

        public void CreateProductProcess_Clicked()
        {
            product.ProductAuthor = user.Username;
            product.ProductDescription = Product_Description.Text;
            product.ProductTitle = Product_Title.Text;
            product.ProductCity = Product_City.Text;
            product.ProductState = Product_State.Text;
            product.ProductMake = Product_Make.Text;
            product.ProductModel = Product_Model.Text;
            product.ProductYear = Product_Year.Text;
            product.ProductPrice = Product_Price.Text;
        }

        //async public SubmitProduct_Clicked(object sender, EventArgs e)
        //{
        //    await ProductService.CreateProduct();
        //}
    }
}