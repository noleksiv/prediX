using System.Collections.Generic;

namespace MoviePrediction.Models
{
    public interface IMovie:IMovieIntro
    {        
        int Budget { get; set; }        
        string Homepage { get; set; }
        string ImdbId { get; set; }    
        int Revenue { get; set; }
        int Runtime { get; set; }
        string Status { get; set; }
        string Tagline { get; set; }

        Collection Collection { get; set; }
        ICollection<Genre> Genres { get; set; }
        ICollection<ProductionCompany> ProductionCompanies { get; set; }
        ICollection<ProductionCountry> ProductionCountries { get; set; }
    }
}
