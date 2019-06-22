using MoviePrediction.Models;
using MoviePrediction.Services.NowPlaying;
using System.Collections.Generic;

namespace MoviePrediction.Services
{
    public interface IMovieHeap: IMovieEnumeration
    {
        NowPlayingMovies GetMovieHeap (int page = 1);
    }

    public interface IMovieEnumeration
    {
        IList<MovieShort> GetMovieEnumeration(int page = 1);
    }
}
