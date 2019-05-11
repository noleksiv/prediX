using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Models
{
    public interface IPoster
    {
        string PosterPath { get; set; }
        string BackdropPath { get; set; }
        Uri PosterUrl { get; set; }
        Uri BackdropUrl { get; set; }
    }
}
