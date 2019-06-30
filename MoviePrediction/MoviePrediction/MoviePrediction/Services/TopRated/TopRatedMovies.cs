using MoviePrediction.Helpers;
using MoviePrediction.Models;
using MoviePrediction.Services.NowPlaying;
using System.Collections.Generic;

namespace MoviePrediction.Services.TopRated
{
    public class TopRatedMovies: DataDeserializer, IMovieEnumeration
    {
        public IList<MovieShort> GetMovieEnumeration(int pageNumb = 1)
        {
            var parameters = $"{TheMovieDbTabs.DatabaseApi}/{TheMovieDbTabs.MovieTab}/{TheMovieDbTabs.TopRatedTab}?{TheMovieDbParameters.Page}={pageNumb}&";
            var movies = ReceiveDeserializedData<ApiMovieResponse<MovieShort>>(parameters);
            return movies.Results;
        }
    }
}
