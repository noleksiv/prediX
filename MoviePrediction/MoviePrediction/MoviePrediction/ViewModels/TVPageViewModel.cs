﻿using MoviePrediction.Helpers;
using MoviePrediction.Models;
using MoviePrediction.Services.Popular;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MoviePrediction.ViewModels
{
    public class TVPageViewModel
    {
        public ObservableCollection<IMovieIntro> PopularTV { get; set; }
        public ObservableCollection<IMovieIntro> TopRatedTV { get; set; }

        public TVPageViewModel()
        {
            FillInPage();
        }

        public void FillInPage()
        {
            var popular = ContentTV(TheMovieDbTabs.PopularTab);
            PopularTV = new ObservableCollection<IMovieIntro>(popular);

            var topRated = ContentTV(TheMovieDbTabs.TopRatedTab);
            TopRatedTV = new ObservableCollection<IMovieIntro>(topRated);
        }

        public IEnumerable<IMovieIntro> ContentTV(string tapName)
        {
            var popularTV = new PopularTV();
            var tvList = popularTV.GetTV(tapName);

            return tvList;
        }
    }
}
