﻿using MoviePrediction.Models;
using System.Collections.Generic;

namespace MoviePrediction.Services.NowPlaying
{
    public class UpcomingMovies: DataDeserializer, IMovieHeap
    {
        public NowPlayingMovies GetMovieHeap(int page = 1)
        {
            var region = System.Globalization.RegionInfo.CurrentRegion.Name;
            var parameters = $"3/movie/upcoming?page={page}&region={region}&";
            var upcomingMovies = ReceiveDeserializedData<NowPlayingMovies>(parameters);
            return upcomingMovies;
        }

        public IList<MovieShort> GetMovieEnumeration(int page = 1)
        {
            var getHeap = GetMovieHeap(page);
            return getHeap.Movies;
        }
    }
}