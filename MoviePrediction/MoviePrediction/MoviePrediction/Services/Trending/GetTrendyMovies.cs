using MoviePrediction.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoviePrediction.Services.Trending
{
    public class GetTrendyMovies
    {
        private TrendyMovies _movies;
        private DataReceiver _dataReceiver;

        private enum MediaType
        {
            All,
            Movie,
            TV,
            Person
        }
        private enum TimeWindow
        {
            Day,
            Week
        }

        public GetTrendyMovies(TrendyMovies trendyMovies)
        {
            _movies = trendyMovies;
            _dataReceiver = new DataReceiver(_movies.MovieDb);
        }

        public IEnumerable<MovieShort> GetMovies()
        {
            var apiKey = _movies.MovieDb.ApiKey;
            var parameters = $"3/trending/{MediaType.All}/{TimeWindow.Week}?api_key={apiKey}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            _movies = JsonConvert.DeserializeObject<TrendyMovies>(jsonStr);
            // return results
            return _movies.Results;
        }
    }
}
