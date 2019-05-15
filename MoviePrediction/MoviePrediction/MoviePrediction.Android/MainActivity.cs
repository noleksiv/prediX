using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Firebase;

namespace MoviePrediction.Droid
{
    [Activity(Label = "MoviePrediction", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            FirebaseApp.InitializeApp(Application.Context);
            ImageCircleRenderer.Init();

            FirebaseOptions options = new FirebaseOptions.Builder()
                                       .SetApplicationId("1:67850015125:android:46afbd6b7ce3fb75") // Required for Analytics.
                                       .SetApiKey("AIzaSyDnsstml-kvxIlCq3Mien85jUhAASAnD9g") // Required for Auth.
                                       .SetDatabaseUrl("https://pred1x.firebaseio.com/") // Required for RTDB.
                                       .Build();

            FirebaseApp.InitializeApp(this, options);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}