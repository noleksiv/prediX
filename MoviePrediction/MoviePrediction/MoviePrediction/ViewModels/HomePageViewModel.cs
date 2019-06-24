using MoviePrediction.CustomViews;
using MoviePrediction.Models;
using MoviePrediction.Services.Trending;
using MoviePrediction.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private IMovieIntro _selectedItem;
        private readonly IPageService _pageService;

        public IMovieIntro SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetValue(ref _selectedItem, value, ItemSelectedCommand);
            }
        }
        public ObservableCollection<IMovieIntro> Movies { get; set; }
        
        public ICommand ItemSelectedCommand { get; private set; }    

        public HomePageViewModel(IPageService pageService)
        {
            _pageService = pageService;

            // Set up a content for a page
            FillInPage();

            // Initialize a command
            ItemSelectedCommand = new Command<IMovieIntro>(async vm => await ItemSelected(vm));
        }

        public void FillInPage()
        {
            var trendyMovies = GetTrendingMovies();
            Movies = new ObservableCollection<IMovieIntro>(trendyMovies);
        }

        public IEnumerable<IMovieIntro> GetTrendingMovies()
        {
            var getMovies = new TrendyMoviesService();
            var movies = getMovies.GetMovies();

            return movies;
        }

        private async Task ItemSelected(IMovieIntro movie)
        {
            try
            {
                await _pageService.PushAsync(new PopupLoading());
                await _pageService.PushAsync(new MovieInfo(movie as MovieShort));
            }
            catch
            {
                
            }
            finally
            {
                SelectedItem = null;
                await _pageService.PopAsync();                
            }
        }
    }
}
