using MoviePrediction.Models;
using System.Collections.Generic;

namespace MoviePrediction.Services.Popular
{
    public class PopularMoviesService: DataDeserializer, IMovieEnumeration
    {
        public IList<MovieShort> GetMovieEnumeration(int pageNumb = 1)
        {
            var parameters = $"3/movie/popular?page={pageNumb}&";
            var movies = ReceiveDeserializedData<PopularMovies>(parameters);
            return movies.Results;
        }
    }
}
