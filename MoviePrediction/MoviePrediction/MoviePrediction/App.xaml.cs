using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MoviePrediction.Views;
using MoviePrediction.Services.Database;
using MoviePrediction.Models;
using MoviePrediction.CustomViews;
using MonkeyCache.SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MoviePrediction
{
    public partial class App : Application
    {
        private static HistoryRepository historyDb;
        private static CacheRepository cacheDb;

        public const string HISTORY_DATABASE_NAME = "history.db";
        public const string CaCHE_DATABASE_NAME = "predix_cache.db";
        
        public static HistoryRepository Database
        {
            get
            {
                if (historyDb == null)
                {
                    historyDb = new HistoryRepository(HISTORY_DATABASE_NAME);
                }
                return historyDb;
            }
        }

        public static CacheRepository CacheDatabase
        {
            get
            {
                if (cacheDb == null)
                {
                    cacheDb = new CacheRepository(CaCHE_DATABASE_NAME);
                }
                return cacheDb;
            }
        }

        public App()
        {
            InitializeComponent();   
            MainPage = new NavigationPage(new LoadingPage());
        }

        protected override void OnStart()
        {
            AutoMapperConfig.Initialize();
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
