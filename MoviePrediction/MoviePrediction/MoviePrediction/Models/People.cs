using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using MoviePrediction.Services.Photo;

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

        public Uri ProfileUrl
        {
            get
            {
                var imageUrl = new ImageUrl();
                var fullPath = imageUrl.CreatePosterLink(ProfilePath);
                var link = new Uri(fullPath);

                return link;
            }
        }
    }
}
