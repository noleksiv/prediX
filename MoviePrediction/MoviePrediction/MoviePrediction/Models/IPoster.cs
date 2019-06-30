using System;

namespace MoviePrediction.Models
{
    public interface IBackdropCompilation
    {
        Uri BackdropUrl { get; }
        string BackdropPath { get; set; }
    }

    public interface IPosterCompilation
    {
        Uri PosterUrl { get; }
        string PosterPath { get; set; }       
        
    }

    public interface IPoster : IPosterCompilation, IBackdropCompilation { }
}
