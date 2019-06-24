using System;
using System.Collections.Generic;
using MoviePrediction.Services.Photo;
using Newtonsoft.Json;

namespace MoviePrediction.Models
{
    public class MovieShort : IMovieIntro
    {
        private string _title;
        private string _name;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name
        {
            get
            {
                return _name != null ? _name : OriginalName;
            }
            set
            {
                if (_name != value)
                    _name = value;
            }
        }

        [JsonProperty("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_count")]
        public int VoteCount { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        public double IMDb
        {
            get => VoteAverage;
        }

        public int Metacritic
        {
            get => (int)(IMDb * 10 - 10);
        }

        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return _title != null ? _title : Name;
            }
            set
            {
                if (_title != value)
                    _title = value;
            }
        }

        [JsonProperty("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("adult")]
        public bool Adult { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("first_air_date")]
        public string FirstAirDate { get; set; }

        [JsonProperty("genre_ids")]
        public ICollection<int> GenreIds { get; set; }

        [JsonProperty("origin_country")]
        public ICollection<string> OriginCountry { get; set; }

        public Uri PosterUrl
        {
            get
            {
                if (PosterPath != null)
                {
                    var imageUrl = new ImageUrl();
                    var link = new Uri(imageUrl.CreatePosterLink(PosterPath));

                    return link;
                }
                else
                {
                    return null;
                }
            }
        }

        public Uri BackdropUrl
        {
            get
            {
                if (BackdropPath != null)
                {
                    var imageUrl = new ImageUrl();
                    var link = new Uri(imageUrl.CreateBackdropLink(BackdropPath));

                    return link;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
