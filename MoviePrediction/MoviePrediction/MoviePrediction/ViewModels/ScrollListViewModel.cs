using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms.Extended;
using Xamarin.Forms;
using System.Threading.Tasks;
using MoviePrediction.CustomViews;
using MoviePrediction.Models;
using MoviePrediction.Views;
using System.Linq;
using MoviePrediction.Convertors;

namespace MoviePrediction.ViewModels
{
    public class ScrollListViewModel: ViewModelBase
    {
        private const int _moviesOnPage = 20;
        private readonly IPageService _pageService;
        private readonly LoadMore _loadMore;
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

        public ScrollListViewModel()
        {
            ItemSelectedCommand = new Command<MovieShort>(async vm => await ItemSelected(vm));
        }

        public ScrollListViewModel(ObservableCollection<MovieShort> moviesList, LoadMore loadMethod, IPageService pageService): this()
        {
            _loadMore = loadMethod;
            _pageService = pageService;

            try
            {
                Movie = new InfiniteScrollCollection<MovieShort>(moviesList)
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
                    OnCanLoadMore = ()=> !_isEnded                   
                };
            }
            catch (Exception) { }
        }

        private IList<MovieShort> LoadMoreMovies()
        {
            var page = Movie.Count / _moviesOnPage;
            var movies = _loadMore(page + 1);
            var nonRepeatedMovies = movies.ExceptObjects(Movie).ToList();
            if (nonRepeatedMovies==null || nonRepeatedMovies.Count == 0)
                _isEnded = true;

            return nonRepeatedMovies;
        }

        private async Task ItemSelected(MovieShort movie)
        {
            try
            {
                await _pageService.PushAsync(new PopupLoading());
                await _pageService.PushAsync(new MovieInfo(movie));                
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
