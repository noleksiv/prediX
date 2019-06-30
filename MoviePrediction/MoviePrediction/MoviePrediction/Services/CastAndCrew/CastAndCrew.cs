using MoviePrediction.Helpers;

namespace MoviePrediction.Services.CastAndCrew
{
    public class CastAndCrew: DataDeserializer
    {
        private readonly int _movieId;

        public CastAndCrew(int movieId)
        {
            _movieId = movieId;
        }

        public MovieCredits GetCredits()
        {
            var parameters = $"{TheMovieDbTabs.DatabaseApi}/{TheMovieDbTabs.MovieTab}/{_movieId}/{TheMovieDbTabs.CreditsTab}?";
            var castAndCrew = ReceiveDeserializedData<MovieCredits>(parameters);
            return castAndCrew;
        }
    }
}
