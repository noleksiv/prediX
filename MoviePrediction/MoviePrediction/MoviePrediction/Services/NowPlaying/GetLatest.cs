using MoviePrediction.Models;
using Newtonsoft.Json;
using Plugin.Multilingual;
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
            var parameters = $"3/movie/now_playing?api_key={_movieDb.ApiKey}&page=1";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var latestMovies = JsonConvert.DeserializeObject<NowPlaying>(jsonStr);

            return latestMovies;
        }

        public IList<MovieShort> GetLatestMovies(int page = 1)
        {
            var parameters = $"3/movie/now_playing?api_key={_movieDb.ApiKey}&page={page}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var latestMovies = JsonConvert.DeserializeObject<NowPlaying>(jsonStr);

            return latestMovies.Movies;
        }

        public NowPlaying GetUpcomingMovies()
        {
            var region = System.Globalization.RegionInfo.CurrentRegion.Name;
            var parameters = $"3/movie/upcoming?api_key={_movieDb.ApiKey}&page=1&region={region}";


            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var latestMovies = JsonConvert.DeserializeObject<NowPlaying>(jsonStr);

            return latestMovies;
        }

        public IList<MovieShort> GetUpcomingMovies(int page = 1)
        {
            var parameters = String.Empty;
            var region = System.Globalization.RegionInfo.CurrentRegion.Name;

            parameters = $"3/movie/upcoming?api_key={_movieDb.ApiKey}&page={page}&region={region}";

            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var latestMovies = JsonConvert.DeserializeObject<NowPlaying>(jsonStr);

            return latestMovies.Movies;
        }
    }
}
