using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.CastAndCrew
{
    public class GetCastAndCrew
    {
        private int _movieId;
        private TheMovieDb _movieDb;
        private DataReceiver _dataReceiver;

        public GetCastAndCrew(int movieId)
        {
            _movieId = movieId;
            _movieDb = new TheMovieDb();
            _dataReceiver = new DataReceiver(_movieDb);
        }

        public MovieCredits GetCredits()
        {
            var parameters = $"3/movie/{_movieId}/credits?api_key={_movieDb.ApiKey}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var castAndCrew = JsonConvert.DeserializeObject<MovieCredits>(jsonStr);
            // return results
            return castAndCrew;
        }
    }
}
