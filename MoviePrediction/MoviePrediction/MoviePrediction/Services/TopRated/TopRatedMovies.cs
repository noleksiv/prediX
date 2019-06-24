using MoviePrediction.Models;
using MoviePrediction.Services.Popular;
using System.Collections.Generic;

namespace MoviePrediction.Services.TopRated
{
    public class TopRatedMovies: DataDeserializer, IMovieEnumeration
    {
        public IList<MovieShort> GetMovieEnumeration(int pageNumb = 1)
        {
            var parameters = $"3/movie/top_rated?page={pageNumb}&";
            var movies = ReceiveDeserializedData<PopularMovies>(parameters);
            return movies.Results;
        }
    }
}
