using MoviePrediction.Models;

namespace MoviePrediction.Services.Photo
{
    public class ImageUrl
    {
        private string _baseUrl = @"http://image.tmdb.org/t/p/";

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

        public string CreatePosterLink(IPoster poster, PosterSize posterSize = PosterSize.w154)
        {
            var url = $"{_baseUrl}{posterSize}{poster.PosterPath}";
            return url;
        }

        public string CreateBackdropLink(IPoster poster, BackdropSize backdropSize = BackdropSize.w720)
        {
            var url = $"{_baseUrl}{backdropSize}{poster.PosterPath}";
            return url;
        }
    }
}
