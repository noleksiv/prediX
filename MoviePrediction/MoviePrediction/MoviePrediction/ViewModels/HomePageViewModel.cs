using MoviePrediction.CustomViews;
using MoviePrediction.Models;
using MoviePrediction.Services.Photo;
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
                SetValue(ref _selectedItem, value);
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
            var trendyMovies = new TrendyMovies();
            var getMovies = new GetTrendyMovies(trendyMovies);
            var movies = getMovies.GetMovies();

            return movies;
        }

        private async Task ItemSelected(IMovieIntro movie)
        {
            try
            {
                await _pageService.PushAsync(new PopupLoading());
                await _pageService.PushAsync(new MovieInfo(movie as MovieShort));
                SelectedItem = null;
            }
            catch
            {
                
            }
            finally
            {
                await _pageService.PopAsync();                
            }
        }
    }
}
