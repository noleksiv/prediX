//using MoviePrediction.Models;
//using MoviePrediction.Services.Popular;
//using Newtonsoft.Json;
//using System.Collections.Generic;

//namespace MoviePrediction.Convertors
//{
//    public class JsonExtractor
//    {
//        public IEnumerable<IMovieIntro> JsonIntoTV(string jsonStr)
//        {
//            var movies = JsonConvert.DeserializeObject<PopularMovies>(jsonStr);
//            return movies.Results;
//        }

//        public T JsonIntoObject<T>(string jsonStr)
//        {
//            var movies = JsonConvert.DeserializeObject<T>(jsonStr);
//            return movies;
//        }
//    }
//}
// TODO: delete also
