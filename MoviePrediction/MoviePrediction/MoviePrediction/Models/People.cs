using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Models
{
    public class People
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("known_for")]
        public ICollection<MovieShort> Movies { get; set; }

        public Uri ProfileUrl { get; set; }
    }
}
