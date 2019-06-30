using Newtonsoft.Json;

namespace MoviePrediction.Services
{
    abstract public class ApiResponse : IResponse
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
