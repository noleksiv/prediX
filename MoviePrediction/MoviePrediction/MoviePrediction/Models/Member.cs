using MoviePrediction.Services.Photo;
using Newtonsoft.Json;
using System;

namespace MoviePrediction.Models
{
    public abstract class Member : IMember
    {
        [JsonProperty("credit_id")]
        public string CreditId { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }

        public Uri ProfileUrl
        {
            get
            {
                var imageUrl = new PosterImage();
                var link = imageUrl.CreatePosterLink(ProfilePath);

                return link;
            }
        }
    }
}
