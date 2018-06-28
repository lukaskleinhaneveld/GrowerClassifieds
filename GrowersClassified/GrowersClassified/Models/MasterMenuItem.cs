using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GrowersClassified.Models
{
    // Setting specifics for menu items
    public class MasterMenuItem
    {
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Color BackgroundColor { get; set; }
        public Type TargetType { get; set; }

        // Context in which you create a new menu item in MasterPage.xaml.cs
       public MasterMenuItem(string Title, string IconSource, Color color, Type target)
       {
            this.Title = Title;
            this.IconSource = IconSource;
            this.BackgroundColor = color;
            this.TargetType = target;
        }
    }
}
