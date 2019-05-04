using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using MoviePrediction.CustomViews;
using MoviePrediction.Droid.CustomViews;

[assembly: ExportRenderer(typeof(BordlessEntry), typeof(BordlessEntryRenderer))]
namespace MoviePrediction.Droid.CustomViews
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class BordlessEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}
