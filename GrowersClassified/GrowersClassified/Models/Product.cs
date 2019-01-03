using System;
using System.Collections.Generic;
using System.Text;

namespace GrowersClassified.Models
{
    // Setting product specifics
    public class Product
    {
        public int Id { get; set; }
        public string ProductAuthor { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCity { get; set; }
        public string ProductState { get; set; }
        public string ProductMake { get; set; }
        public string ProductModel { get; set; }
        public string ProductYear { get; set; }
        public string ProductPrice { get; set; }

        //private string productAuthor;
        //private string productTitle;
        //private string productDescription;
        //private string productCity;
        //private string productState;
        //private string productMake;
        //private string productModel;
        //private string productYear;
        //private string productPrice;

        //public int Id { get; set; }
        //public string ProductAuthor { get { return productAuthor; } set { productAuthor = value; } }
        //public string ProductTitle { get { return productAuthor; } set { productAuthor = value; } }
        //public string ProductDescription { get { return productAuthor; } set { productAuthor = value; } }
        //public string ProductCity { get { return productAuthor; } set { productAuthor = value; } }
        //public string ProductState { get { return productAuthor; } set { productAuthor = value; } }
        //public string ProductMake { get { return productAuthor; } set { productAuthor = value; } }
        //public string ProductModel { get { return productAuthor; } set { productAuthor = value; } }
        //public string ProductYear { get { return productAuthor; } set { productAuthor = value; } }
        //public string ProductPrice { get { return productAuthor; } set { productAuthor = value; } }

        //public Product(string productAuthor, string productTitle, string productDescription, string productCity, string productState, string productMake, string productModel, string productYear, string productPrice)
        //{
        //    this.productAuthor = ProductAuthor;
        //    this.productTitle = ProductTitle;
        //    this.productDescription = ProductDescription;
        //    this.productCity = ProductCity;
        //    this.productState = ProductState;
        //    this.productMake = ProductMake;
        //    this.productModel = ProductModel;
        //    this.productYear = ProductYear;
        //    this.productPrice = ProductPrice;
        //}

        //public String ToString(String fmt)
        //{
        //    if (String.IsNullOrEmpty(fmt))
        //        fmt = "G";

        //    switch (fmt.ToUpperInvariant())
        //    {
        //        case "All":
        //            return String.Format("{0} {1}", this.ProductAuthor, this.ProductTitle, ProductDescription, ProductCity, ProductState, ProductMake, ProductModel, ProductYear, ProductPrice);

        //        default:
        //            String msg = String.Format("'{0}' is an invalid format string", fmt);
        //            throw new ArgumentException(msg);
        //    }
        //}
    }
}
