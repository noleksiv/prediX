﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviePrediction.Models;
using MoviePrediction.Services.Trending;
using System.Collections.ObjectModel;
using MoviePrediction.Services.Photo;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        private ImageUrl imageUrl = new ImageUrl();
        public ObservableCollection<IMovieIntro> Movies { get; set; }

        public HomePage ()
		{
			InitializeComponent ();
            FillInPage();            
            this.BindingContext = this;
        }

        public void FillInPage()
        {
            var trendyMovies =  GetTrendingMovies();
            Movies = new ObservableCollection<IMovieIntro>(trendyMovies);

            foreach (var movie in Movies)
            {
                movie.PosterUrl = new Uri(imageUrl.CreatePosterLink(movie));
            }                
        }

        public IEnumerable<IMovieIntro> GetTrendingMovies()
        {
            var movies = FillMoviesData();
            return movies;
        }

        public IEnumerable<IMovieIntro> FillMoviesData()
        {
            var trendyMovies = new TrendyMovies();
            var getMovies = new GetTrendyMovies(trendyMovies);
            var movies = getMovies.GetMovies();
            return movies;               
        }
	}
}