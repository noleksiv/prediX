using MoviePrediction.Models;
using Newtonsoft.Json;
using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.NowPlaying
{
    public class GetLatest: IMovieHeap
    {
        private TheMovieDb _movieDb;
        private DataReceiver _dataReceiver;

        public GetLatest()
        {
            _movieDb = new TheMovieDb();
            _dataReceiver = new DataReceiver(_movieDb);
        }

        public NowPlayingMovies GetMovieHeap(int page = 1)
        {
            var parameters = $"3/movie/now_playing?api_key={_movieDb.ApiKey}&page={page}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);
            var latestMovies = JsonConvert.DeserializeObject<NowPlayingMovies>(jsonStr);
            return latestMovies;
        }

        public IList<MovieShort> GetMovieEnumeration(int page = 1)
        {
            var getHeap = GetMovieHeap(page);
            return getHeap.Movies;
        }
    }
}
