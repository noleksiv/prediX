using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace MoviePrediction.Services
{
    public class DataReceiver
    {
        private IApiCredentials _credentials;

        public DataReceiver(IApiCredentials credentials)
        {
            _credentials = credentials;
        }

        public string GetRequestJson(string param)
        {
            var json = String.Empty;
            var url = _credentials.SiteLink + param;

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            return json;
        }
    }
}
