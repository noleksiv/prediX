using MoviePrediction.Models;
using MoviePrediction.Services;
using MoviePrediction.Services.Popular;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Convertors
{
    public class JsonExtractor
    {
        public IEnumerable<IMovieIntro> JsonIntoTV(string jsonStr)
        {
            var movies = JsonConvert.DeserializeObject<PopularMovies>(jsonStr);
            return movies.Results;
        }
    }
}
