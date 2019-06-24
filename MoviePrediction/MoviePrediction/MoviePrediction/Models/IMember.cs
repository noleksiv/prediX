using System;

namespace MoviePrediction.Models
{
    public interface IMember: IEntity
    {
        string CreditId { get; set; }
        int Gender { get; set; }
        string ProfilePath { get; set; }
        Uri ProfileUrl { get; }
    }
}
