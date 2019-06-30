using MoviePrediction.Helpers;
using MoviePrediction.Models;
using MoviePrediction.Services.NowPlaying;
using System.Collections.Generic;

namespace MoviePrediction.Services.Popular
{
    public class PopularMoviesService: DataDeserializer, IMovieEnumeration
    {
        public IList<MovieShort> GetMovieEnumeration(int pageNumb = 1)
        {
            var parameters = $"{TheMovieDbTabs.DatabaseApi}/{TheMovieDbTabs.MovieTab}/{TheMovieDbTabs.PopularTab}?{TheMovieDbParameters.Page}={pageNumb}&";
            var movies = ReceiveDeserializedData<ApiMovieResponse<MovieShort>>(parameters);
            return movies.Results;
        }
    }
}
