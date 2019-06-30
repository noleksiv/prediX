using MoviePrediction.Helpers;
using MoviePrediction.Models;
using MoviePrediction.Services.NowPlaying;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviePrediction.Services.Popular
{
    public class PopularTV: DataDeserializer, ISerialEnumerator
    {
        public string DefaultParameters { get => $"{TheMovieDbTabs.DatabaseApi}/{TheMovieDbTabs.TvTab}/"; }

        public IEnumerable<IMovieIntro> GetTV(string tapName, int pageNumb = 1)
        {
            var parameters = DefaultParameters + $"{tapName}?{TheMovieDbParameters.Page}={pageNumb}&";
            var movies = ReceiveDeserializedData<ApiMovieResponse<MovieShort>>(parameters);
            return movies.Results;
        }

        public async Task<IEnumerable<IMovieIntro>> GetTVAsync(string tapName, int pageNumb = 1)
        {
            var parameters = DefaultParameters + $"{tapName}?{TheMovieDbParameters.Page}={pageNumb}&";
            var movies = await ReceiveDeserializedDataAsync<ApiMovieResponse<MovieShort>>(parameters);
            return movies.Results;
        }
    }
}
