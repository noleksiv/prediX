using MoviePrediction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoviePrediction.Convertors
{
    public class ObjectsComparer<T> : IEqualityComparer<T> where T : IMovieIntro
    {
        public bool Equals(T x, T y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(T obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    public static class ObjectsExtension
    {
        public static IEnumerable<T> ExceptObjects<T> (this IList<T> first, IList<T> second) where T : IMovieIntro
        {
            return first.Except(second, new ObjectsComparer<T>());
        }
    }
}
