using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using GrowersClassified.Models;
using System.Text;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace GrowersClassified.Data
{
    public class ProductService
    {
        private HttpClient _client;

        public ProductService()
        {
            // Creating new HttpClient and sets the maximum number of bytes to buffer when reading the response content 
            _client = new HttpClient { MaxResponseContentBufferSize = 256000 };
            // Specify request type
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public void CreateProduct(Product product)
        {
            return;
        }
    }
}