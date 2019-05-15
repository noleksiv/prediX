using System.IO;
using MoviePrediction.Droid;
using MoviePrediction.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(SqlLiteAndroid))]
namespace MoviePrediction.Droid
{
    class SqlLiteAndroid : ISQLite
    {
        public SqlLiteAndroid() { }

        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }    
    }
}