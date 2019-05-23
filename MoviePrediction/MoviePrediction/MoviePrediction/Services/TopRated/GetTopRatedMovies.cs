using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.TopRated
{
    public class GetTopRatedMovies
    {
        private TheMovieDb _movieDb;
        private DataReceiver _dataReceiver;

        public GetTopRatedMovies()
        {
            _movieDb = new TheMovieDb();
            _dataReceiver = new DataReceiver(_movieDb);
        }

        public IList<MovieShort> GetTopMovies(int pageNumb = 1, string region = "en-US")
        {
            var parameters = $"3/movie/top_rated?api_key={_movieDb.ApiKey}&language={region}&page={pageNumb}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var movies = JsonConvert.DeserializeObject<TopRated>(jsonStr);
            // return results
            return movies.Movies;
        }
    }
}
