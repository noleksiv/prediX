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
            var parameters = $"3/movie/{_movieId}/credits?";
            var castAndCrew = ReceiveDeserializedData<MovieCredits>(parameters);
            return castAndCrew;
        }
    }
}
