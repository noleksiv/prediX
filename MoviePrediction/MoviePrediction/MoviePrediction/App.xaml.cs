using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MoviePrediction.Views;
using MoviePrediction.Services.Database;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MoviePrediction
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "history.db";

        public static HistoryRepository database;
        public static HistoryRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new HistoryRepository(DATABASE_NAME);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            //Application.Current.Properties["SessionId"] =null;
            //Application.Current.Properties["Uid"] =null;
            //MainPage = new NavigationPage(new Registration());
        }

        protected override void OnStart()
        {
            if (Application.Current.Properties.ContainsKey("SessionId"))
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
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
