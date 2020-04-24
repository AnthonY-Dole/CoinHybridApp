
using Android.Content;
using Android.Graphics.Drawables;

using CoinHybridApp.Controls;
using CoinHybridApp.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessPicker), typeof(BordlessPickerRenderer))]
namespace CoinHybridApp.Droid.Renderer
{
   
    
    public class BordlessPickerRenderer : PickerRenderer
    {
        public BordlessPickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

          
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(20f);
                gradientDrawable.SetStroke(2, Android.Graphics.Color.Rgb(52, 73, 94));
                gradientDrawable.SetColor(Android.Graphics.Color.Transparent); Control.SetBackground(gradientDrawable);
            
            

        }
    }

    }
