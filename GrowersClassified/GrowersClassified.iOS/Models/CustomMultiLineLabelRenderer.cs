using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using GrowersClassified.iOS.Models;
using GrowersClassified.Models;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MultiLineLabel), typeof(CustomMultiLineLabelRenderer))]
namespace GrowersClassified.iOS.Models
{
    public class CustomMultiLineLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            MultiLineLabel multiLineLabel = (MultiLineLabel)Element;

            if (multiLineLabel != null && multiLineLabel.Lines != -1)
                Control.Lines = multiLineLabel.Lines;
        }
    }
}