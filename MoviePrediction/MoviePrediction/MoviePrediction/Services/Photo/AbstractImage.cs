using MoviePrediction.Helpers;
using System;

namespace MoviePrediction.Services.Photo
{
    public abstract class AbstractImage
    {
        private const string _baseUrl = LinksContainer.TmdbAbsolute;

        public virtual Uri CreateImageLink(string partPath, string size)
        {
            var fullPath = $"{_baseUrl}{size}{partPath}";
            var url = new Uri(fullPath);
            return url;
        }
    }  
}
