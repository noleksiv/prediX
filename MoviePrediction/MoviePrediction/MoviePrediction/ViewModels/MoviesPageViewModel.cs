using MoviePrediction.CustomViews;
using MoviePrediction.Models;
using MoviePrediction.Resources;
using MoviePrediction.Services;
using MoviePrediction.Services.NowPlaying;
using MoviePrediction.Services.Popular;
using MoviePrediction.Services.TopRated;
using MoviePrediction.Views;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public class MoviesPageViewModel: ViewModelBase
    {
        private readonly MovieTap _tap;
        private readonly IPageService _pageService;
        private const int _numbOfMovies = 5;
        private LoadMore _loadMore;        
        private IMovieIntro _selectedItem;

        public string Title { get; set; }
        public string LatestStartDate { get; set; }
        public string LatestEndsDate { get; set; }

        public string PlayingDate
        {
            get
            {
                if (LatestEndsDate != null)
                    return $"{AppResources.FromDateLabel} {LatestStartDate} {AppResources.ToDateLabel} {LatestEndsDate}";
                else
                    return String.Empty;
            }
        }
        public IMovieIntro SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                SetValue(ref _selectedItem, value, ItemSelectedCommand);
            }
        }       

        public ObservableCollection<MovieShort> ShortDescription { get; set; }
        public ObservableCollection<MovieShort> FullDescription { get; set; }

        public ICommand ItemSelectedCommand { get; private set; }
        public ICommand ShowMoreCommand { get; private set; }

        public MoviesPageViewModel(MovieTap tap, IPageService pageService)
        {
            _tap = tap;
            _pageService = pageService;

            ShowMoreCommand = new Command(async()=> await ShowMoreClicked());
            ItemSelectedCommand = new Command<IMovieIntro>(async vm => await ItemSelected(vm));
            
            ReceiveContent();
        }
        private void ReceiveContent()
        {
            GetMovies();
        }

        private void GetMovies()
        {
            switch (_tap)
            {
                case MovieTap.Latest:
                    Title = AppResources.NowPlayingLabel;
                    var getLatest = new Latest();
                    GetContentHeap(getLatest);
                    break;

                case MovieTap.Upcoming:
                    Title = AppResources.SoonLabel;
                    var getUpcoming = new UpcomingMovies();
                    GetContentHeap(getUpcoming);
                    break;

                case MovieTap.Popular:
                    Title = AppResources.PopularMovieLabel;
                    var getPopular = new PopularMoviesService();
                    GetContentList(getPopular);
                    break;

                case MovieTap.Toprated:
                    Title = AppResources.TopRatedMovieLabel;
                    var getTopRated = new TopRatedMovies();
                    GetContentList(getTopRated);
                    break;

                default:
                    break;
            }
        }

        public void GetContentHeap<T> (T context) where T : IMovieHeap
        {
            var contextMovies = context.GetMovieHeap();
            _loadMore = new LoadMore(context.GetMovieEnumeration);           

            FullDescription = new ObservableCollection<MovieShort>(contextMovies.Movies);

            LatestStartDate = contextMovies.Dates.From;
            LatestEndsDate = contextMovies.Dates.UntilTo;

            ShortDescription = new ObservableCollection<MovieShort>(FullDescription.Take(_numbOfMovies));
        }

        public void GetContentList<T> (T context) where T : IMovieEnumeration
        {
            var contextMovies = context.GetMovieEnumeration();
            _loadMore = new LoadMore(context.GetMovieEnumeration);            

            FullDescription = new ObservableCollection<MovieShort>(contextMovies);
            ShortDescription = new ObservableCollection<MovieShort>(FullDescription.Take(_numbOfMovies));
        }


        private async Task ShowMoreClicked()
        {
            try
            {
                await _pageService.PushAsync(new PopupPage());
                await _pageService.PushAsync(new MovieScrollList(FullDescription, _loadMore, _pageService));
            }
            catch (Exception)
            {

            }
            finally
            {
                await _pageService.PopAsync();
            }
        }

        private async Task ItemSelected(IMovieIntro movie)
        {
            try
            {
                await _pageService.PushAsync(new PopupLoading());
                await _pageService.PushAsync(new MovieInfo(movie as MovieShort));
            }
            catch (Exception ex)
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
