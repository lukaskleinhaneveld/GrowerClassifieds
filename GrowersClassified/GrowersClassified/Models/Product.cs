using System;
using System.Collections.Generic;
using System.Text;

namespace GrowersClassified.Models
{
    // Setting product specifics
    class Product
    {
        public int Id { get; set; }
        public string Product_Author { get; set; }
        public string Product_Title { get; set; }
        public string Product_Description { get; set; }
        public string Product_Make { get; set; }
        public string Product_Model { get; set; }
        public string Product_Year { get; set; }
        public string Product_Price { get; set; }

        // Context in which you create a new productin ProductPage.xaml.cs
        public Product(string Product_Author, string Product_Title, string Product_Description, string Product_Make, string Product_Model, string Product_Year, string Product_Price)
        {
            this.Product_Author = Product_Author;
            this.Product_Title = Product_Title;
            this.Product_Description = Product_Description;
            this.Product_Make = Product_Make;
            this.Product_Model = Product_Model;
            this.Product_Year = Product_Year;
            this.Product_Price = Product_Price;
        }
    }
}
