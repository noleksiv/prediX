using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.NowPlaying
{
    public class UpcomingMovies: IMovieHeap
    {
        private TheMovieDb _movieDb;
        private DataReceiver _dataReceiver;

        public UpcomingMovies()
        {
            _movieDb = new TheMovieDb();
            _dataReceiver = new DataReceiver(_movieDb);
        }

        public NowPlayingMovies GetMovieHeap(int page = 1)
        {
            var region = System.Globalization.RegionInfo.CurrentRegion.Name;
            var parameters = $"3/movie/upcoming?api_key={_movieDb.ApiKey}&page={page}&region={region}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);
            var upcomingMovies = JsonConvert.DeserializeObject<NowPlayingMovies>(jsonStr);
            return upcomingMovies;
        }

        public IList<MovieShort> GetMovieEnumeration(int page = 1)
        {
            var getHeap = GetMovieHeap(page);
            return getHeap.Movies;
        }
    }
}
