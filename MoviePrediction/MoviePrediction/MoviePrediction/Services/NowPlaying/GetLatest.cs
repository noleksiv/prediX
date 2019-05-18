using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.NowPlaying
{
    public class GetLatest
    {
        private TheMovieDb _movieDb;
        private DataReceiver _dataReceiver;

        public GetLatest()
        {
            _movieDb = new TheMovieDb();
            _dataReceiver = new DataReceiver(_movieDb);
        }

        public NowPlaying GetLatestMovies()
        {
            var parameters = $"3/movie/now_playing?api_key={_movieDb.ApiKey}&language=en-US&page=1";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var latestMovies = JsonConvert.DeserializeObject<NowPlaying>(jsonStr);

            return latestMovies;
        }

        public IList<MovieShort> GetLatestMovies(int page = 1, string language = "en - US")
        {
            var parameters = $"3/movie/now_playing?api_key={_movieDb.ApiKey}&language={language}&page={page}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var latestMovies = JsonConvert.DeserializeObject<NowPlaying>(jsonStr);

            return latestMovies.Movies;
        }

        public NowPlaying GetUpcomingMovies()
        {
            var parameters = $"3/movie/upcoming?api_key={_movieDb.ApiKey}&language=en-US&page=1";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var latestMovies = JsonConvert.DeserializeObject<NowPlaying>(jsonStr);

            return latestMovies;
        }

        public IList<MovieShort> GetUpcomingMovies(int page = 1, string region = "ua")
        {
            var parameters = String.Empty;

            if (region!=null)
            {
                parameters = $"3/movie/upcoming?api_key={_movieDb.ApiKey}&language=en-US&page={page}&region={region}";
            }
            else
            {
                parameters = $"3/movie/upcoming?api_key={_movieDb.ApiKey}&language=en-US&page={page}";
            }
            
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var latestMovies = JsonConvert.DeserializeObject<NowPlaying>(jsonStr);

            return latestMovies.Movies;
        }
    }
}
