using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.CastAndCrew
{
    public class MovieCredits
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("cast")]
        public ICollection<Cast> Cast { get; set; }

        [JsonProperty("crew")]
        public ICollection<Crew> Crew { get; set; }
    }
}
