using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviePrediction.Services.TopRated
{
    public class GetTopRatedTV
    {
        private TheMovieDb _movieDb;
        private DataReceiver _dataReceiver;

        public GetTopRatedTV()
        {
            _movieDb = new TheMovieDb();
            _dataReceiver = new DataReceiver(_movieDb);
        }

        public IEnumerable<IMovieIntro> GetTopTV(int pageNumb = 1)
        {
            var parameters = $"3/tv/top_rated?api_key={_movieDb.ApiKey}&language=en-US&page={pageNumb}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var movies = JsonConvert.DeserializeObject<TopRated>(jsonStr);
            // return results
            return movies.Movies;
        }

        public async Task<IEnumerable<IMovieIntro>> GetTopTVAsync(int pageNumb = 1)
        {
            var parameters = $"3/tv/top_rated?api_key={_movieDb.ApiKey}&language=en-US&page={pageNumb}";
            var jsonStr = await _dataReceiver.GetJsonAsync(parameters);

            return await Task.Run(() => 
            {
                var movies = JsonConvert.DeserializeObject<TopRated>(jsonStr);
                // return results
                return movies.Movies;
            });
           
        }
    }
}
