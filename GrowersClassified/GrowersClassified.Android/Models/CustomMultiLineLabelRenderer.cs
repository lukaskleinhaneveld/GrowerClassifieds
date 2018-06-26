using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GrowersClassified.Droid.Models;
using GrowersClassified.Models;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(MultiLineLabel), typeof(CustomMultiLineLabelRenderer))]

namespace GrowersClassified.Droid.Models
{
    public class CustomMultiLineLabelRenderer : LabelRenderer
    {
        // The method below is used to complete the "LabelRenderer" class. Without this method, the LabelRenderer class is absolute
        public CustomMultiLineLabelRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            MultiLineLabel multiLineLabel = (MultiLineLabel)Element;

            if (multiLineLabel != null && multiLineLabel.Lines != -1)
            {
                Control.SetSingleLine(false);
                Control.SetLines(multiLineLabel.Lines);
            }
        }
    }
}