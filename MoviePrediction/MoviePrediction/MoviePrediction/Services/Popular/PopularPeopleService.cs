using MoviePrediction.Helpers;
using MoviePrediction.Models;
using MoviePrediction.Services.NowPlaying;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviePrediction.Services.Popular
{
    public class PopularPeopleService : DataDeserializer
    {
        public string DefaultParameters { get => $"{TheMovieDbTabs.DatabaseApi}/{TheMovieDbTabs.PersonTab}/{TheMovieDbTabs.PopularTab}?"; }

        public IEnumerable<People> GetPeople(int pageNumb = 1)
        {
            var parameters = DefaultParameters + $"{TheMovieDbParameters.Page}={pageNumb}&";
            var people = ReceiveDeserializedData<ApiMovieResponse<People>>(parameters);
            return people.Results;
        }

        public async Task<IEnumerable<People>> GetPeopleAsync(int pageNumb = 1)
        {
            var parameters = DefaultParameters + $"{TheMovieDbParameters.Page}={pageNumb}&";
            var people = await ReceiveDeserializedDataAsync<ApiMovieResponse<People>>(parameters);
            return people.Results;
        }
    }
}
