using GrowersClassified.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowersClassified.Views.Products
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage : ContentPage
    {
        // Setting ListView to the x:Name of the listview in the xaml page
        public ListView ListView { get { return ProductList; } }
        // Setting instance of GetProducts so we can load the products from another file
        public GetProducts getProducts = new GetProducts();
        public ActivityIndicator LoadingProducts { get { return loadingProducts; } }
        public Label LoadingProductsLbl { get { return loadingProductsLbl; } }
        public ProductPage ()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            getProducts.LoadAllProducts(ListView, LoadingProducts, loadingProductsLbl);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            await Navigation.PushAsync(new ProductDetail());
            ((ListView)sender).SelectedItem = null;
        }
    }
}