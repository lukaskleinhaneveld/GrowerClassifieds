using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrowersClassified.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrowersClassified.Views.Menu
{
   public partial class MasterDetail : MasterDetailPage
   {
        public MasterDetail()
        {
            NavigationPage.SetHasNavigationBar(this, false); // Removing the title bar
            InitializeComponent();
            masterpage.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
       {
            if (e.SelectedItem is MasterMenuItem item)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterpage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}