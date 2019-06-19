using System.Collections.Generic;
using MoviePrediction.Models;

namespace MoviePrediction.Services
{
    public interface IResponse
    {
        int Page { get; set; }
        int TotalPages { get; set; }
    }
}
