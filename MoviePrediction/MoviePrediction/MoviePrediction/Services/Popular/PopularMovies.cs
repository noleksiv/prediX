using MoviePrediction.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoviePrediction.Services.Popular
{
    public class PopularMovies : ApiResponse
    {
        [JsonProperty("results")]
        public ICollection<MovieShort> Results { get; set; }
    }
}
