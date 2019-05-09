using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Models
{
    public interface IMember
    {
        string CreditId { get; set; }
        int Gender { get; set; }
        int Id { get; set; }
        string Name { get; set; }
        string ProfilePath { get; set; }
        Uri ProfileUrl { get; set; }
    }
}
