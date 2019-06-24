using MoviePrediction.Models;
using System.Collections.Generic;

namespace MoviePrediction.Services.Trending
{
    public class TrendyMoviesService: DataDeserializer
    {
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

        public IEnumerable<MovieShort> GetMovies()
        {
            var parameters = $"3/trending/{MediaType.Movie}/{TimeWindow.Week}?";
            var _movies = ReceiveDeserializedData<TrendyMovies>(parameters);
            return _movies.Results;             
        }
    }
}
