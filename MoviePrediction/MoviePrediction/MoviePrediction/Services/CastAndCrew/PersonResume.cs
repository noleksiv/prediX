using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.CastAndCrew
{
    public class PersonResume
    {
        [JsonProperty("cast")]
        public IList<MovieShort> Cast { get; set; }
    }
}
