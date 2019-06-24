using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using MonkeyCache.SQLite;
using Plugin.Connectivity;
using Plugin.Multilingual;

namespace MoviePrediction.Services
{
    public class DataReceiver
    {
        private readonly MonkeyCache _cache;
        private readonly CultureInfo _cuppentCulture;

        public string RequestEnding
        {
            get
            {
                var pathEnding = $"api_key={TheMovieDb.ApiKey}&language={_cuppentCulture}";
                return pathEnding;
            }
        }

        static DataReceiver()
        {
            App.CacheDatabase.Initialization();
        }

        public DataReceiver()
        {
            _cache = new MonkeyCache();
            _cuppentCulture = CrossMultilingual.Current.CurrentCultureInfo;
        }

        public string GetRequestJson(string param)
        {
            var json = String.Empty;
            var url = TheMovieDb.SiteLink + param + RequestEnding;

            if (!CrossConnectivity.Current.IsConnected)
                _cache.GetCachedData(url);

            // Checking if cache is expired
            if (!Barrel.Current.IsExpired(key: url))
                _cache.GetCachedData(url);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            _cache.SaveData(url, json);

            return json;
        }

        public async Task<string> GetJsonAsync(string param)
        {
            var json = String.Empty;
            var url = TheMovieDb.SiteLink + param + RequestEnding;

            if (!CrossConnectivity.Current.IsConnected)
                _cache.GetCachedData(url);

            // Checking if cache is expired
            if (!Barrel.Current.IsExpired(key: url))
                _cache.GetCachedData(url);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            return await Task.Run(async() => 
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    json = await reader.ReadToEndAsync();
                }

                _cache.SaveData(url, json);

                return json;
            });           
        }
    }
}
