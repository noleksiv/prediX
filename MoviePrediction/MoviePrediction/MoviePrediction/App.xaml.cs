using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviePrediction.Services.Database;
using MoviePrediction.Models;
using MoviePrediction.CustomViews;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MoviePrediction
{
    public partial class App : Application
    {
        private static HistoryRepository historyDb;
        private static CacheRepository cacheDb;
        
        public static HistoryRepository Database
        {
            get
            {
                if (historyDb == null)
                {
                    historyDb = new HistoryRepository(DatabaseNames.HistoryDatabase);
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
                    cacheDb = new CacheRepository(DatabaseNames.CacheDatabase);
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
