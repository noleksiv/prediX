using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services
{
    public class TheMovieDb : IApiCredentials
    {
        public string SiteLink { get; set; } = @"https://api.themoviedb.org/";
        public string ApiKey { get; private set; } = "15854b836e7d12b1d8e122960da34dec";
    }
}
