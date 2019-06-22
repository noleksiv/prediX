using MoviePrediction.Services.Photo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Models
{
    public class PersonProfile
    {
        private string _deathday;
        private string _profilePath;

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("known_for_department")]
        public string KnownForDepartment { get; set; }

        [JsonProperty("deathday")]
        public string Deathday
        {
            get
            {
                return _deathday ?? "-";
            }
            set
            {
                if (value != _deathday)
                {
                    _deathday = value;
                }
            }
        }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("also_known_as")]
        public IEnumerable<string> AlsoKnownAs { get; set; }

        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("place_of_birth")]
        public string PlaceOfBirth { get; set; }

        [JsonProperty("profile_path")]
        public string ProfilePath
        {
            get
            {
                var imageUrl = new ImageUrl();
                var fullPath = imageUrl.CreatePosterLink(_profilePath);

                return fullPath;
            }
            set
            {
                if (_profilePath != value)
                    _profilePath = value;
            }
        }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("homepage")]
        public string Homepage { get; set; }

        public string ProfileUrl
        {
            get => $"https://www.imdb.com/name/{ImdbId}/";
        }

        public string Pseudonyms
        {
            get => GetPenName();
        }

        public string Rate
        {
            get => GetStarRating();
        }

        public string GetPenName()
        {
            var penName = new StringBuilder();

            foreach (var pen in AlsoKnownAs)
            {
                penName.Append(pen + "\n");
            }

            return penName.ToString();
        }

        public string GetStarRating()
        {
            if (Popularity > 10)
            {
                return "stars5.jpg";
            }
            if (Popularity > 8)
            {
                return "stars4.jpg";
            }
            if (Popularity > 6)
            {
                return "stars3.jpg";
            }
            if (Popularity > 2.5)
            {
                return "stars2.jpg";
            }
            else
            {
                return "stars1.jpg";
            }
        }
    }
}
