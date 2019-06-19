using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.NowPlaying
{
    public class NowPlaying : ApiMovieResponse
    {
        [JsonProperty("dates")]
        public Date Dates { get; set; }        
    }

    public class ApiMovieResponse : ApiResponse
    {
        [JsonProperty("results")]
        public IList<MovieShort> Movies { get; set; }
    }
}
