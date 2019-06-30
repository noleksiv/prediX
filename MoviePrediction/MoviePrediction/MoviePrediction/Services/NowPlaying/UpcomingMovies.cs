using MoviePrediction.Helpers;
using MoviePrediction.Models;
using System.Collections.Generic;

namespace MoviePrediction.Services.NowPlaying
{
    public class UpcomingMovies: DataDeserializer, IMovieHeap
    {
        public NowPlayingMovies GetMovieHeap(int page = 1)
        {
            var region = System.Globalization.RegionInfo.CurrentRegion.Name;
            var parameters = $"{TheMovieDbTabs.DatabaseApi}/{TheMovieDbTabs.MovieTab}/{TheMovieDbTabs.UpcomingTab}?{TheMovieDbParameters.Page}={page}&{TheMovieDbParameters.Region}={region}&";
            var upcomingMovies = ReceiveDeserializedData<NowPlayingMovies>(parameters);
            return upcomingMovies;
        }

        public IList<MovieShort> GetMovieEnumeration(int page = 1)
        {
            var getHeap = GetMovieHeap(page);
            return getHeap.Results;
        }
    }
}
