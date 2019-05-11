using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.Popular
{
    public class PopularPeople : ApiResponse
    {
        [JsonProperty("results")]
        public ICollection<People> People { get; set; }
    }
}
