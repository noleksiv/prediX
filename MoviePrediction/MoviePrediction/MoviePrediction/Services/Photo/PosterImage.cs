using System;
using MoviePrediction.Models;

namespace MoviePrediction.Services.Photo
{
    public enum BackdropSize
    {
        w300,
        w720,
        w1280,
        original
    }
    public enum PosterSize
    {
        w92,
        w154,
        w185,
        w342,
        w500,
        w780,
        original
    }  

    public class PosterImage : AbstractImage
    {
        public Uri CreatePosterLink(string partPath, PosterSize posterSize = PosterSize.w500) => CreateImageLink(partPath, posterSize.ToString());
        public Uri CreatePosterLink(IPoster poster, PosterSize posterSize = PosterSize.w500) => CreatePosterLink(poster.PosterPath, posterSize);
    }

    public class BackdropImage : AbstractImage
    {
        public Uri CreateBackdropLink(string partPath, BackdropSize backdropSize = BackdropSize.w1280) => CreateImageLink(partPath, backdropSize.ToString());
        public Uri CreateBackdropLink(IPoster poster, BackdropSize backdropSize = BackdropSize.w720) => CreateBackdropLink(poster.PosterPath, backdropSize);
    }
}
