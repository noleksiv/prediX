using System.Collections.Generic;

namespace MoviePrediction.Models
{
    public interface IMovieIntro : IEntity, IPoster
    {
        bool Video { get; set; }
        int VoteCount { get; set; }
        double VoteAverage { get; set; }
        string Title { get; set; }
        string ReleaseDate { get; set; }
        string OriginalLanguage { get; set; }
        string OriginalTitle { get; set; }
        bool Adult { get; set; }
        string Overview { get; set; }
        double Popularity { get; set; }
        string OriginalName { get; set; }
        string FirstAirDate { get; set; }

        ICollection<int> GenreIds { get; set; }
        ICollection<string> OriginCountry { get; set; }
    }
}
