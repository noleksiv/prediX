using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services
{
    public interface IApiCredentials
    {
        string SiteLink { get; set; }
        string ApiKey { get; }
    }
}
