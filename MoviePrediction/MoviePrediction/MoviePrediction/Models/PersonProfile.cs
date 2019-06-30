using MoviePrediction.Helpers;
using MoviePrediction.Services.Photo;
using Newtonsoft.Json;
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
                var imageUrl = new PosterImage();
                var link = imageUrl.CreatePosterLink(_profilePath);

                return link.ToString();
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
            get => $"{LinksContainer.Imdb}name/{ImdbId}/";
        }

        public string Pseudonyms
        {
            get => GetPenNames();
        }

        public string Rate
        {
            get => GetStarRating();
        }

        /// <summary>
        /// Connecting all persons pen names in a string.
        /// </summary>
        public string GetPenNames()
        {
            var penName = new StringBuilder();

            foreach (var pen in AlsoKnownAs)
            {
                penName.Append(pen + "\n");
            }

            return penName.ToString();
        }

        /// <summary>
        /// Converting a double value into a 5 stars rating.
        /// </summary>
        /// <returns>Return popularity through stars</returns>
        public string GetStarRating()
        {            
            if (Popularity > 10)
                return ImageNames.FiveStars;

            if (Popularity > 8)
                return ImageNames.FourStars;

            if (Popularity > 6)
                return ImageNames.ThreeStars;

            if (Popularity > 2.5)
                return ImageNames.TwoStars;

            return ImageNames.OneStar;
        }
    }
}
