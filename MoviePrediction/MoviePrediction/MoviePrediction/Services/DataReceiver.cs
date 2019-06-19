using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using MonkeyCache;
using MonkeyCache.SQLite;
using Plugin.Connectivity;
using Plugin.Multilingual;

namespace MoviePrediction.Services
{
    public class DataReceiver
    {
        private IApiCredentials _credentials;

        static DataReceiver()
        {
            App.CacheDatabase.Initialization();
        }

        public DataReceiver(IApiCredentials credentials)
        {
            _credentials = credentials;
        }

        public string GetRequestJson(string param)
        {
            var json = String.Empty;
            var currentCulture = CrossMultilingual.Current.CurrentCultureInfo;
            var url = _credentials.SiteLink + param + $"&language={currentCulture}";

            if (!CrossConnectivity.Current.IsConnected)
            {
                return Barrel.Current.Get<string>(key: url);
            }

            // Checking if cache is expired
            if (!Barrel.Current.IsExpired(key: url))
            {
                return Barrel.Current.Get<string>(key: url);
            }

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            // Cache lifetime
            var duration = 1;
            // Add to cache
            Barrel.Current.Add(key: url, data: json, expireIn: TimeSpan.FromDays(duration));

            return json;
        }

        public async Task<string> GetJsonAsync(string param)
        {
            var json = String.Empty;
            var currentCulture = CrossMultilingual.Current.CurrentCultureInfo;
            var url = _credentials.SiteLink + param + $"&language={currentCulture}";

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

                return json;
            });           
        }
    }
}
