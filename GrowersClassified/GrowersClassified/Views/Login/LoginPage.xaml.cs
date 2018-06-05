using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GrowersClassified.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace GrowersClassified.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public void LoginProcess_Clicked()
        {
            string Name = Entry_Name.Text;
            string Pass = Entry_Pass.Text;
        }
    }
}