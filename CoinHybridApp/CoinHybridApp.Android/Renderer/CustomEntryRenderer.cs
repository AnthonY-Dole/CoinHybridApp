using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CoinHybridApp.Controls;
using CoinHybridApp.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Java.Util.ResourceBundle;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace CoinHybridApp.Droid.Renderer
{
   public class CustomEntryRenderer : EntryRenderer

    {

        public CustomEntryRenderer(Context context): base(context)
    {
    }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
    {
            base.OnElementChanged(e);


        var gradientDrawable = new GradientDrawable();
        gradientDrawable.SetCornerRadius(20f);
        gradientDrawable.SetStroke(4, Android.Graphics.Color.Rgb(48, 79, 254));
        gradientDrawable.SetColor(Android.Graphics.Color.Transparent); 
            Control.SetBackground(gradientDrawable);



    }
    }
}