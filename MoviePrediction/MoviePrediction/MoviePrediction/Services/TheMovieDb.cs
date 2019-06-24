using MoviePrediction.Helpers;

namespace MoviePrediction.Services
{
    public class TheMovieDb : IApiCredentials
    {
        public string SiteLink { get; set; } = LinksContainer.TheMovieDb;
        public string ApiKey { get; private set; } = LinksContainer.ApiKey;
    }
}
