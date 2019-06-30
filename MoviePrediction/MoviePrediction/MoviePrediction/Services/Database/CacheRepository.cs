using MonkeyCache.SQLite;
using MoviePrediction.Helpers;
using MoviePrediction.Models;
using Xamarin.Forms;

namespace MoviePrediction.Services.Database
{
    public class CacheRepository
    {
        public CacheRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            Barrel.Create(databasePath);
        }

        public void Initialization()
        {
            Barrel.ApplicationId = ApplicationProperties.ApplicationId;
        }
    }
}
