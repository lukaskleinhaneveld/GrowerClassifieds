using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace GrowersClassified.Models
{
    public class Product
    {
        private HttpClient _client;

        string productAuthor;
        string productTitle;
        string productDescription;
        string productCity;
        string productState;
        string productMake;
        string productModel;
        string productYear;
        string productPrice;

        public Product(string productAuthor, string productTitle, string productDescription, string productCity, string productState, string productMake, string productModel, string productYear, string productPrice)
        {
            this.productAuthor = productAuthor;
            this.productTitle = productTitle;
            this.productDescription = productDescription;
            this.productCity = productCity;
            this.productState = productState;
            this.productMake = productMake;
            this.productModel = productModel;
            this.productYear = productYear;
            this.productPrice = productPrice;
        }
    }
}
