using MoviePrediction.Convertors;
using MoviePrediction.CustomViews;
using MoviePrediction.Models;
using MoviePrediction.Services.NowPlaying;
using MoviePrediction.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace MoviePrediction.ViewModels
{
    public class PredictionPageViewModel: ViewModelBase
    {
        private const int _moviesOnPage = 20;
        private readonly IPageService _pageService;
        private MovieShort _selectedItem;
        private bool _isEnded;
        private bool _isBusy;

        public MovieShort SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetValue(ref _selectedItem, value, ItemSelectedCommand);
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetValue(ref _isBusy, value);
            }
        }

        public InfiniteScrollCollection<MovieShort> Movie { get; set; }

        public ICommand ItemSelectedCommand { get; private set; }

        public PredictionPageViewModel()
        {
            ItemSelectedCommand = new Command<MovieShort>(async vm => await ItemSelected(vm));
        }

        public PredictionPageViewModel(IPageService pageService): this()
        {
            _pageService = pageService;

            try
            {
                Movie = new InfiniteScrollCollection<MovieShort>()
                {
                    OnLoadMore = async () =>
                    {
                        IsBusy = true;
                        await _pageService.PushAsync(new PopupLoading());
                        var movies = LoadMoreMovies();
                        await _pageService.PopAsync();
                        IsBusy = false;
                        return movies;
                    },
                    OnCanLoadMore = () => !_isEnded
                };

                var movieList = LoadMoreMovies();
                Movie.AddRange(movieList);
            }
            catch (Exception) { }
        }

        private IList<MovieShort> LoadMoreMovies()
        {
            var upcoming = new UpcomingMovies();
            var page = Movie.Count / _moviesOnPage;
            var movies = upcoming.GetMovieEnumeration(page + 1);
            var nonRepeatedMovies = movies.ExceptObjects(Movie).ToList();

            if (nonRepeatedMovies == null || nonRepeatedMovies.Count == 0)
                _isEnded = true;

            return nonRepeatedMovies;
        }

        private async Task ItemSelected(MovieShort movie)
        {
            try
            {
                await _pageService.PushAsync(new PopupLoading());
                await _pageService.PushAsync(new PredictionResult(movie));
            }
            finally
            {
                SelectedItem = null;
                await _pageService.PopAsync();
            }
        }

        private async void GoToMainPage()
        {
            await _pageService.PushAsync(new HomePage());
        }
    }
}
