using MoviePrediction.Convertors;
using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviePrediction.Services.Popular
{
    public class PopularTV: BarrelTV, ISerialEnumerator
    {
        public IEnumerable<IMovieIntro> GetTV(string tapName, int pageNumb = 1)
        {
            var jsonStr = base.GetTVJson(tapName);
            var jsonExtr = new JsonExtractor();
            var movies = jsonExtr.JsonIntoTV(jsonStr);
            return movies;
        }

        public async Task<IEnumerable<IMovieIntro>> GetTVAsync(string tapName, int pageNumb = 1)
        {
            var jsonStr = await base.GetTVJsonAsync(tapName);

            return await Task.Run(() => 
            {
                var jsonExtr = new JsonExtractor();
                var movies = jsonExtr.JsonIntoTV(jsonStr);
                return movies;
            });

        }
    }
}
