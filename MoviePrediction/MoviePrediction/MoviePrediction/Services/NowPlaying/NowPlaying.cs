using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.NowPlaying
{
    public class NowPlaying : ApiResponse
    {
        [JsonProperty("dates")]
        public Date Dates { get; set; }

        [JsonProperty("results")]
        public IList<MovieShort> Movies { get; set; }
    }
}
