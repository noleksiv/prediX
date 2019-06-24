using System;

namespace MoviePrediction.Services.Photo
{
    public class PosterLocator
    {
        public Uri GetImageUrl<T>(T pathContributor, string path) where T: class
        {            
            if (!typeof(T).IsSubclassOf(typeof(Delegate)))
                return null;

            if (path == null)
                return null;

            var imageUrl = new ImageUrl();
            var link = new Uri(pathContributor.Execute);

            return link;
        }
    }
}
