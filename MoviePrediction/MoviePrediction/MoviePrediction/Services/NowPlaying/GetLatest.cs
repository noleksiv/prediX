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

        public NowPlaying GetLatestMovies(int page=1)
        {
            var parameters = $"3/movie/now_playing?api_key={_movieDb.ApiKey}&language=en-US&page={page}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var latestMovies = JsonConvert.DeserializeObject<NowPlaying>(jsonStr);

            return latestMovies;
        }

        public NowPlaying GetUpcomingMovies(int page = 1)
        {
            var parameters = $"3/movie/upcoming?api_key={_movieDb.ApiKey}&language=en-US&page={page}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var latestMovies = JsonConvert.DeserializeObject<NowPlaying>(jsonStr);

            return latestMovies;
        }
    }
}
