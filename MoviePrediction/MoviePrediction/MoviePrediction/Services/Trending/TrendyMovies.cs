using System.Collections.Generic;
using MoviePrediction.Models;
using Newtonsoft.Json;

namespace MoviePrediction.Services.Trending
{
    public class TrendyMovies : ApiResponse
    {
        [JsonProperty("results")]
        public ICollection<MovieShort> Results { get; set; }
    }
}
