using System.Collections.Generic;
using System.Linq;
using MoviePrediction.Models;

namespace MoviePrediction.Expansions
{
    public class ObjectsComparer<T> : IEqualityComparer<T> where T : IMovieIntro
    {
        public bool Equals(T x, T y) => x.Id == y.Id;

        public int GetHashCode(T obj) => obj.Id.GetHashCode();
    }

    public static class ObjectsExtension
    {
        public static IEnumerable<T> ExceptObjects<T> 
            (this IList<T> first, IList<T> second) where T : IMovieIntro
        {
            return first.Except(second, new ObjectsComparer<T>());
        }
    }
}
