using MoviePrediction.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviePrediction.Services
{
    public interface ISerialEnumerator
    {
        IEnumerable<IMovieIntro> GetTV(string tapName, int pageNumb = 1);
        Task<IEnumerable<IMovieIntro>> GetTVAsync(string tapName, int pageNumb = 1);
    }
}
