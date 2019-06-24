using System;

namespace MoviePrediction.Models
{
    public interface IPosterString
    {
        string PosterPath { get; set; }
        string BackdropPath { get; set; }
    }

    public interface IPosterUrl
    {
        Uri PosterUrl { get; }
        Uri BackdropUrl { get; }
    }

    public interface IPoster : IPosterString, IPosterUrl { }
}
