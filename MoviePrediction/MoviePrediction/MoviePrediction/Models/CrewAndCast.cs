using Newtonsoft.Json;

namespace MoviePrediction.Models
{
    public class Crew : Member, ICrew
    {
        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }
    }

    public class Cast : Member, ICast
    {
        [JsonProperty("cast_id")]
        public int CastId { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }

        [JsonProperty("order")]
        public int Order { get; set; }
    }
}
