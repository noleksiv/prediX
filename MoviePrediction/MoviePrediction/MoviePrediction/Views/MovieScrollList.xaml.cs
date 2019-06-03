﻿using MoviePrediction.CustomViews;
using MoviePrediction.Models;
using MoviePrediction.Resources;
using MoviePrediction.Services.Photo;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Extended;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieScrollList : ContentPage, INotifyPropertyChanged
	{
        private bool _isBusy;
        private readonly int _moviesOnPage = 20;
        private ImageUrl imageUrl = new ImageUrl();
        private LoadMore _loadMore;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public InfiniteScrollCollection<MovieShort> Movie { get; set; }


        public MovieScrollList ()
		{
			InitializeComponent ();            
        }

        public MovieScrollList(ObservableCollection<MovieShort> moviesList, LoadMore loadMethod) : this()
        {
            _loadMore=loadMethod;

            Movie = new InfiniteScrollCollection<MovieShort>(moviesList);

            Movie.OnLoadMore = async () =>
           {
               IsBusy = true;
               await PopupNavigation.Instance.PushAsync(new PopupLoading());
               var movies = LoadMoreMovies();
               await PopupNavigation.Instance.PopAsync();
               return movies;
           }; 

            this.BindingContext = this;
        }

        private IList<MovieShort> LoadMoreMovies()
        {
            var page = Movie.Count / _moviesOnPage;

            var movies = _loadMore(page+1);

            foreach (var movie in movies)
            {
               movie.PosterUrl = new Uri(imageUrl.CreatePosterLink(movie.PosterPath));
            }

            return movies;          
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void MovieItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            try
            {
                await PopupNavigation.Instance.PushAsync(new PopupLoading());

                var selectedItem = ((ListView)sender).SelectedItem;
                var movie = selectedItem as MovieShort;

                await Navigation.PushAsync(new MovieInfo(movie));

            }
            catch (Exception ex)
            {
                await DisplayAlert(AppResources.WarningTitle, ex.Message, AppResources.ConfirmText, AppResources.CancelText);
            }
            finally
            {
                shotrListView.SelectedItem = null;
                await PopupNavigation.Instance.PopAsync();
            }
        }

        private async void GoToMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
    }
}