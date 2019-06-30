using MoviePrediction.Helpers;
using MoviePrediction.Models;
using System.Collections.Generic;

namespace MoviePrediction.Services.NowPlaying
{
    public class Latest: DataDeserializer, IMovieHeap
    {
        public NowPlayingMovies GetMovieHeap(int page = 1)
        {
            var parameters = $"{TheMovieDbTabs.DatabaseApi}/{TheMovieDbTabs.MovieTab}/{TheMovieDbTabs.NowPlayingsTab}?{TheMovieDbParameters.Page}={page}&";
            var latestMovies = ReceiveDeserializedData<NowPlayingMovies>(parameters);
            return latestMovies;
        }

        public IList<MovieShort> GetMovieEnumeration(int page = 1)
        {
            var getHeap = GetMovieHeap(page);
            return getHeap.Results;
        }
    }
}
