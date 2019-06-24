using MoviePrediction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviePrediction.Services.Popular
{
    public class PopularTV: DataDeserializer, ISerialEnumerator
    {

        public IEnumerable<IMovieIntro> GetTV(string tapName, int pageNumb = 1)
        {
            var parameters = $"3/tv/{tapName}?page={pageNumb}&";          
            var movies = ReceiveDeserializedData<PopularMovies>(parameters);
            return movies.Results;
        }

        public async Task<IEnumerable<IMovieIntro>> GetTVAsync(string tapName, int pageNumb = 1)
        {
            var parameters = $"3/tv/{tapName}?page={pageNumb}&";
            var movies = await ReceiveDeserializedDataASync<PopularMovies>(parameters);
            return movies.Results;

        }
    }
}
