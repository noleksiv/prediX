namespace MoviePrediction.Services
{
    public interface IApiCredentials
    {
        string SiteLink { get; set; }
        string ApiKey { get; }
    }
}
