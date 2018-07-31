using GrowersClassified.Data;
using GrowersClassified.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrowersClassified.Views.Products
{
    public partial class CreateProduct : ContentPage
    {
        User user = new User();
        HttpClient _client = new HttpClient();
        MediaFile file = null;
        public ActivityIndicator Loading_Indicator { get { return loading; } }
        //public ActivityIndicator Submitting_Indicator { get { return submittin; } }

        public CreateProduct()
        {
            InitializeComponent();
            MainImage.IsVisible = false;
            //createProductProcess.IsEnabled = false;

            #region Taking a photo
            takePhoto.Clicked += async (sender, args) =>
            {
                Loading_Indicator.IsVisible = true;
                await CrossMedia.Current.Initialize();
                await CreateProductProgress.ProgressTo(0.3, 200, Easing.Linear);

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", "No Camera Available.", "OK");
                    return;
                }
                file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true,
                        AllowCropping = true,

                    });
                await CreateProductProgress.ProgressTo(0.3, 600, Easing.Linear);
                MainImage.IsVisible = true;
                Loading_Indicator.IsVisible = false;
                if (file == null)
                    return;


                MainImage.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
                createProductProcess.IsEnabled = true;
            };
            #endregion

            #region Picking a photo
            pickPhoto.Clicked += async (sender, args) =>
            {
                //CreateProductProgress.ProgressTo(1,200, Easing.Linear);
                Loading_Indicator.IsVisible = true;
                createProductProcess.IsEnabled = false;
                await CrossMedia.Current.Initialize();
                await CreateProductProgress.ProgressTo(0.3, 200, Easing.Linear);

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Photos Not Supported", "Permission not granted to photos.", "OK");
                    return;
                }
                await CreateProductProgress.ProgressTo(0.3, 600, Easing.Linear);

                file = await CrossMedia.Current.PickPhotoAsync();
                MainImage.IsVisible = true;
                Loading_Indicator.IsVisible = false;

                if (file == null)
                    return;

                MainImage.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
                createProductProcess.IsEnabled = true;
            };
            #endregion

            #region clicking button to post item
            createProductProcess.Clicked += async (sender, args) =>
            {
                createProductProcess.Text = "Submitting";
                createProductProcess.IsEnabled = false;

                // Check if all fields are filled
                if (Product_Title.Text != "" &&
                   Product_City.Text != "" &&
                   Product_State.Text != "" &&
                   Product_Model.Text != "" &&
                   Product_Make.Text != "" &&
                   Product_Year.Text != "" &&
                   Product_Price.Text != "" &&
                   MainImage.Source != null &&
                   Product_Description.Text != "")
                {
                    CreateProductProgress.IsVisible = true;
                    await CreateProductProgress.ProgressTo(0.3, 700, Easing.Linear);
                    UploadImage(file);
                    await CreateProductProgress.ProgressTo(1, 600, Easing.Linear);
                }
                else
                {
                    createProductProcess.Text = "Submit";
                    Message.TextColor = Color.Red;
                    Message.Text = "Not all fields were filled. Please revise and try again.";
                    createProductProcess.IsEnabled = true;
                }
                Navigation.InsertPageBefore(new Index(), this);
                await Navigation.PopAsync();
            };
            #endregion
        }

        #region upload to FTP
        public async void uploadToFTP(MediaFile file)
        {
            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.iOS)
            {
                try
                {
                    //Submitting_Indicator.IsVisible = true;
                    await Task.Delay(1000);
                    DependencyService.Get<IFtpWebRequest>().upload(Constants.FTP_URL, file.Path, Constants.FTP_Username, Constants.FTP_UserPassword, Constants.FTP_Location);
                    //Submitting_Indicator.IsVisible = false;
                    await Task.Delay(1000);
                    Navigation.InsertPageBefore(new Index(), this);
                    await Navigation.PopAsync();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error found: " + ex);
                    await DisplayAlert("Error:", "There was an error uploading the image. Please select one and upload again.", "OK");
                }
            }
        }
        #endregion

        #region UploadImage
        public async void UploadImage(MediaFile file)
        {
            var Token = App.TokenDatabase.GetToken();
            byte[] byteData = System.Text.Encoding.UTF8.GetBytes(file.Path);
            var postData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("date", DateTime.Now.ToString()),
                new KeyValuePair<string, string>("date_gmt", DateTime.Now.ToString()),
                new KeyValuePair<string, string>("slug", "upload_" + DateTime.Now),
                new KeyValuePair<string, string>("satus", "publish"),
                new KeyValuePair<string, string>("title", "upload_" + DateTime.Now),
                new KeyValuePair<string, string>("title", Token.Nickname),
                new KeyValuePair<string, string>("comment_status", "closed"),
                new KeyValuePair<string, string>("ping_status", "closed"),
                new KeyValuePair<string, string>("image", byteData.ToString()),
                new KeyValuePair<string, string>("alt_text",""),
                new KeyValuePair<string, string>("caption",""),
                new KeyValuePair<string, string>("description",""),
                new KeyValuePair<string, string>("post",""),
                new KeyValuePair<string, string>("media_type", "image")
            };

            var uploadable = new FormUrlEncodedContent(postData);

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token.AccessToken);

            await Task.Run(() =>
            {
                var postResult = _client.PostAsync(Constants.PostImage, uploadable).Result;
            });
        }
        #endregion
    }
}