using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.NowPlaying
{
    public class NowPlayingMovies : ApiMovieResponse<MovieShort>
    {
        [JsonProperty("dates")]
        public Date Dates { get; set; }        
    }

    public class ApiMovieResponse<T> : ApiResponse
    {
        [JsonProperty("results")]
        public IList<T> Results { get; set; }
    }
}
