using GrowersClassified.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowersClassified.Views.Contact
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactPage : ContentPage
	{
		public ContactPage ()
		{
            InitializeComponent ();
            if (CheckNetwork.IsInternet())
            {
                // Code
            }
            else
            {
                ErrMessage.IsVisible = true;
                ErrMessage.TextColor = Color.Red;
                ErrMessage.Text = "You're not connected to the internet. Please make sure you are connected to use the app.";
            }
        }
	}
}