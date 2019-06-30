using MoviePrediction.Helpers;
using MoviePrediction.Models;
namespace MoviePrediction.Services.CastAndCrew
{
    public class ProfileInfo : DataDeserializer
    {
        private readonly int _personId;
        public string DefaultParameters { get => $"{TheMovieDbTabs.DatabaseApi}/{ TheMovieDbTabs.PersonTab}/{_personId}/"; }

        public ProfileInfo(int personId)
        {
            _personId = personId;
        }

        public PersonProfile GetInfo()
        {
            var parameters = DefaultParameters  + "?";
            var info = ReceiveDeserializedData<PersonProfile>(parameters);
            return info;
        }

        public PersonResume GetHistory()
        {
            var parameters = DefaultParameters + $"{TheMovieDbTabs.MovieCreditsTab}?";
            var history = ReceiveDeserializedData<PersonResume>(parameters);
            return history;
        }
    }
}
