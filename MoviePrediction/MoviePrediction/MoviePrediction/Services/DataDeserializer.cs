using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MoviePrediction.Services
{
    public abstract class DataDeserializer
    {
        protected DataReceiver _dataReceiver;

        public DataDeserializer()
        {
            _dataReceiver = new DataReceiver();
        }

        public T ReceiveDeserializedData<T>(string parameters)
        {
            var jsonStr = _dataReceiver.GetRequestJson(parameters);
            var castAndCrew = JsonConvert.DeserializeObject<T>(jsonStr);
            return castAndCrew;
        }

        public async Task<T> ReceiveDeserializedDataASync<T>(string parameters)
        {
            var jsonStr = await _dataReceiver.GetJsonAsync(parameters);
            var castAndCrew = JsonConvert.DeserializeObject<T>(jsonStr);
            return castAndCrew;
        }
    }
}
