using MoviePrediction.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviePrediction.Services.Popular
{
    public class PopularPeopleService : DataDeserializer
    {
        public IEnumerable<People> GetPeople(int pageNumb = 1)
        {
            var parameters = $"3/person/popular?page={pageNumb}&";
            var people = ReceiveDeserializedData<PopularPeople>(parameters);
            return people.People;
        }

        public async Task<IEnumerable<People>> GetPeopleAsync(int pageNumb = 1)
        {
            var parameters = $"3/person/popular?page={pageNumb}&";
            var people = await ReceiveDeserializedDataASync<PopularPeople>(parameters);
            return people.People;
        }
    }
}
