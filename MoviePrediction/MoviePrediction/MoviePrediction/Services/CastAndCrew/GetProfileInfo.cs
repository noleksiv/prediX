using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.CastAndCrew
{
    public class GetProfileInfo
    {
        private int _personId;
        private TheMovieDb _movieDb;
        private DataReceiver _dataReceiver;

        public GetProfileInfo(int personId)
        {
            _personId = personId;
            _movieDb = new TheMovieDb();
            _dataReceiver = new DataReceiver(_movieDb);
        }

        public PersonProfile GetInfo()
        {
            var parameters = $"3/person/{_personId}/?api_key={_movieDb.ApiKey}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var info = JsonConvert.DeserializeObject<PersonProfile>(jsonStr);

            return info;
        }

        public PersonResume GetHistory()
        {
            var parameters = $"3/person/{_personId}/movie_credits?api_key={_movieDb.ApiKey}&language=en-US";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var history = JsonConvert.DeserializeObject<PersonResume>(jsonStr);

            return history;
        }
    }
}
