using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviePrediction.Services.Popular
{
    public class GetPopularPeople
    {
        private TheMovieDb _movieDb;
        private DataReceiver _dataReceiver;

        public GetPopularPeople()
        {
            _movieDb = new TheMovieDb();
            _dataReceiver = new DataReceiver(_movieDb);
        }

        public IEnumerable<People> GetPeople(int pageNumb = 1)
        {
            var parameters = $"3/person/popular?api_key={_movieDb.ApiKey}&page={pageNumb}";
            var jsonStr = _dataReceiver.GetRequestJson(parameters);

            var people = JsonConvert.DeserializeObject<PopularPeople>(jsonStr);
            // return results
            return people.People;
        }

        public async Task<IEnumerable<People>> GetPeopleAsync(int pageNumb = 1)
        {
            var parameters = $"3/person/popular?api_key={_movieDb.ApiKey}&page={pageNumb}";
            var jsonStr = await _dataReceiver.GetJsonAsync(parameters);

            return await Task.Run(() => 
            {
                var people = JsonConvert.DeserializeObject<PopularPeople>(jsonStr);
                // return results
                return people.People;
            }); 
        }
    }
}
