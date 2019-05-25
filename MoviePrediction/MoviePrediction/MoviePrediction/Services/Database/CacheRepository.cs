using MonkeyCache.SQLite;
using MoviePrediction.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
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
            Barrel.ApplicationId = "com.companyname";
        }
    }
}
