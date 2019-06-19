using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.Popular
{
    public class GetPopularMovies
    {
        private TheMovieDb _movieDb;
        private DataReceiver _dataReceiver;

        public GetPopularMovies()
        {
            _movieDb = new TheMovieDb();
            _dataReceiver = new DataReceiver(_movieDb);
        }

        public IList<MovieShort> GetMovies(int pageNumb = 1)
        {
            var parameters = $"3/movie/popular?api_key={_movieDb.ApiKey}&page={pageNumb}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var movies = JsonConvert.DeserializeObject<PopularMovies>(jsonStr);
            // return results
            return movies.Results;
        }
    }
}
