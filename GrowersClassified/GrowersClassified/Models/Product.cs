using System;
using System.Collections.Generic;
using System.Text;

namespace GrowersClassified.Models
{
    // Setting product specifics
    public class Product
    {
        private int Id { get; set; }
        private string _product_Author { get; set; }
        private string _product_Title { get; set; }
        private string _product_Description { get; set; }
        private string _product_City { get; set; }
        private string _product_State { get; set; }
        private string _product_Make { get; set; }
        private string _product_Model { get; set; }
        private string _product_Year { get; set; }
        private string _product_Price { get; set; }

        // Context and order in which you create a new productin ProductPage.xaml.cs
        public Product(string Product_Author, string Product_Title, string Product_Description, string Product_City, string Product_State, string Product_Make, string Product_Model, string Product_Year, string Product_Price)
        {
            this._product_Author = Product_Author;
            this._product_Title = Product_Title;
            this._product_Description = Product_Description;
            this._product_City = Product_City;
            this._product_State = Product_State;
            this._product_Model = Product_Model;
            this._product_Year = Product_Year;
            this._product_Price = Product_Price;
        }

        public string Product_Author { get { return _product_Author; } }
        public string Product_Title { get { return _product_Title; } }
        public string Product_Description { get { return _product_Description; } }
        public string Product_City { get { return _product_City; } }
        public string Product_State { get { return _product_State; } }
        public string Product_Make { get { return _product_Make; } }
        public string Product_Model { get { return _product_Model; } }
        public string Product_Year { get { return _product_Year; } }
        public string Product_Price { get { return _product_Price; } }

        public String ToString(String fmt)
        {
            if (String.IsNullOrEmpty(fmt))
                fmt = "G";

            switch (fmt.ToUpperInvariant())
            {
                case "All":
                    return String.Format("{0} {1}", _product_Author, _product_Title, _product_Description, _product_City, _product_State, _product_Make, _product_Model, _product_Year,_product_Price);

                default:
                    String msg = String.Format("'{0}' is an invalid format string", fmt);
                    throw new ArgumentException(msg);
            }
        }
    }
}
