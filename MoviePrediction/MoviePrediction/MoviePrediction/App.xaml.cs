using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MoviePrediction.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MoviePrediction
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Application.Current.Properties["SessionId"] =null;
            //Application.Current.Properties["Uid"] =null;
            //MainPage = new NavigationPage(new Registration());
        }

        protected override void OnStart()
        {
            System.Diagnostics.Debug.WriteLine(new string('*', 50));
            foreach (var item in Application.Current.Properties)
            {
                System.Diagnostics.Debug.WriteLine(item.Key + "\t" + item.Value);
            }
            if (Application.Current.Properties.ContainsKey("SessionId"))
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new NavigationPage(new Registration());
            }
        }

        protected override void OnSleep()
        {
            Application.Current.SavePropertiesAsync();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
