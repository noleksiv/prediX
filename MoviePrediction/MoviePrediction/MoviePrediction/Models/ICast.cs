﻿namespace MoviePrediction.Models
{
    public interface ICast : IMember
    {
       int CastId { get; set; }
       string Character { get; set; }
       int Order { get; set; }
    }
}
