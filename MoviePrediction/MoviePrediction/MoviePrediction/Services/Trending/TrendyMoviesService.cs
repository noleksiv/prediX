using MoviePrediction.Helpers;
using MoviePrediction.Models;
using MoviePrediction.Services.NowPlaying;
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
            var parameters = $"{TheMovieDbTabs.DatabaseApi}/{TheMovieDbTabs.TrendingTab}/{MediaType.Movie}/{TimeWindow.Week}?";
            var _movies = ReceiveDeserializedData<ApiMovieResponse<MovieShort>>(parameters);
            return _movies.Results;             
        }
    }
}
