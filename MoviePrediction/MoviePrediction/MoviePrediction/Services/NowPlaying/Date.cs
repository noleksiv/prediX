using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.NowPlaying
{
    public class Date
    {
        [JsonProperty("minimum")]
        public string From { get; set; }

        [JsonProperty("maximum")]
        public string UntilTo { get; set; }
    }
}
