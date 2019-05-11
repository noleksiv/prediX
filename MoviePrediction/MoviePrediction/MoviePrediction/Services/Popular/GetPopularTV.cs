using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviePrediction.Services.Popular
{
    public class GetPopularTV
    {
        private TheMovieDb _movieDb;
        private DataReceiver _dataReceiver;

        public GetPopularTV()
        {
            _movieDb = new TheMovieDb();
            _dataReceiver = new DataReceiver(_movieDb);
        }

        public IEnumerable<IMovieIntro> GetTV(int pageNumb = 1)
        {
            var parameters = $"3/tv/popular?api_key={_movieDb.ApiKey}&language=en-US&page={pageNumb}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var movies = JsonConvert.DeserializeObject<PopularMovies>(jsonStr);
            // return results
            return movies.Results;
        }

        public async Task<IEnumerable<IMovieIntro>> GetTVAsync(int pageNumb = 1)
        {
            var parameters = $"3/tv/popular?api_key={_movieDb.ApiKey}&language=en-US&page={pageNumb}";
            var jsonStr = await _dataReceiver.GetJsonAsync(parameters);

            return await Task.Run(() => 
            {
                var movies = JsonConvert.DeserializeObject<PopularMovies>(jsonStr);

                return movies.Results;
            });

        }
    }
}
