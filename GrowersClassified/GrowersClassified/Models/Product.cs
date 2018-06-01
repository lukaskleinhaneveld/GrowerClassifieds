using System;
using System.Collections.Generic;
using System.Text;

namespace GrowersClassified.Models
{
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
        //public string ContactInfo { get; set; }
    }
}
