using MoviePrediction.Models;
namespace MoviePrediction.Services.CastAndCrew
{
    public class ProfileInfo : DataDeserializer
    {
        private readonly int _personId;

        public ProfileInfo(int personId)
        {
            _personId = personId;
        }

        public PersonProfile GetInfo()
        {
            var parameters = $"3/person/{_personId}/?";

            var info = ReceiveDeserializedData<PersonProfile>(parameters);

            return info;
        }

        public PersonResume GetHistory()
        {
            var parameters = $"3/person/{_personId}/movie_credits?";

            var history = ReceiveDeserializedData<PersonResume>(parameters);

            return history;
        }
    }
}
