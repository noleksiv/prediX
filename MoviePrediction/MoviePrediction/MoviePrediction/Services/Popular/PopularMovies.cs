using MoviePrediction.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MoviePrediction.Services.Popular
{
    public class PopularMovies : ApiResponse
    {
        [JsonProperty("results")]
        public IList<MovieShort> Results { get; set; }
    }
}
