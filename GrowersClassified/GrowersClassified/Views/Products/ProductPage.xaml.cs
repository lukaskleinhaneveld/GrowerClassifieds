using GrowersClassified.Data;
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
            if (CheckNetwork.IsInternet())
            {
                getProducts.LoadAllProducts(ListView, LoadingProducts, loadingProductsLbl);
            }
            else
            {
                ErrMessage.IsVisible = true;
                ErrMessage.TextColor = Color.Red;
                ErrMessage.Text = "You're not connected to the internet. Please make sure you are connected to use the app.";
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            await Navigation.PushAsync(new ProductDetail(e.SelectedItem));
            ((ListView)sender).SelectedItem = null;
        }
    }
}