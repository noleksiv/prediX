using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviePrediction.Services
{
    public abstract class BarrelTV: DataDeserializer
    {
        public string GetTVJson(string tap, int pageNumb = 1)
        {
            var parameters = $"3/tv/{tap}?page={pageNumb}&";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            return jsonStr;
        }

        public async Task<string> GetTVJsonAsync(string tap, int pageNumb = 1)
        {
            var parameters = $"3/tv/{tap}?page={pageNumb}&";
            var jsonStr = await _dataReceiver.GetJsonAsync(parameters);

            return jsonStr;
        }
    }
}
