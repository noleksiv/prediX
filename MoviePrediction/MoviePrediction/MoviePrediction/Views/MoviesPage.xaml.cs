using MoviePrediction.Models;
using MoviePrediction.Services.NowPlaying;
using MoviePrediction.Services.Photo;
using MoviePrediction.Services.Popular;
using MoviePrediction.Services.TopRated;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
    public delegate IList<MovieShort> LoadMore(int pageNumber, string language = "en-US");

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviesPage : ContentPage
	{
        private ImageUrl _imageUrl;
        private MovieTap _tap;
        private LoadMore _loadMore;

        public bool IsBusy { get; set; }

        public string Title { get; set; }
        public string LatestStartDate { get; set; }
        public string LatestEndsDate { get; set; }
        public string PlayingDate {
            get
            {
                if (LatestEndsDate != null)
                    return $"From {LatestStartDate} to {LatestEndsDate}";
                else
                    return "";
            }
        }

        public ObservableCollection<IMovieIntro> ShortDescription { get; set; }
        public ObservableCollection<MovieShort> FullDescription { get; set; }

        public MoviesPage()
        {
            InitializeComponent();
        }

        public MoviesPage (MovieTap tap) : this()
		{
            _tap = tap;
            ReceiveContent();
            this.BindingContext = this;
        }

        private void ReceiveContent()
        {
            _imageUrl = new ImageUrl();
            GetMovies();
        }
        
        private void GetMovies()
        {
            switch (_tap)
            {
                case MovieTap.Latest:
                    Title = "Now playing";
                    GetLatest();
                    break;
                case MovieTap.Upcoming:
                    Title = "Soon will be";
                    GetUpcoming();
                    break;
                case MovieTap.Popular:
                    Title = "Popular";
                    GetPopularMovies();
                    break;
                case MovieTap.Toprated:
                    Title = "Top rated";
                    GetTopRatedMovies();
                    break;
                default:
                    break;
            }
        }

        public void GetLatest(int pageNumber=1)
        {
            var latest = new GetLatest();
            _loadMore = new LoadMore(latest.GetLatestMovies);
            var latestMovies = latest.GetLatestMovies();           

            FullDescription = new ObservableCollection<MovieShort>(latestMovies.Movies);            

            LatestStartDate = latestMovies.Dates.From;
            LatestEndsDate = latestMovies.Dates.UntilTo;

            foreach (var movie in FullDescription)
            {
                movie.PosterUrl = new System.Uri(_imageUrl.CreatePosterLink(movie.PosterPath));
            }

            ShortDescription = new ObservableCollection<IMovieIntro>(FullDescription.Take(5));
        }

        public void GetUpcoming()
        {
            var upcoming = new GetLatest();

            _loadMore = new LoadMore(upcoming.GetUpcomingMovies);

            var upcomingMovies = upcoming.GetUpcomingMovies();

            FullDescription = new ObservableCollection<MovieShort>(upcomingMovies.Movies);

            LatestStartDate = upcomingMovies.Dates.From;
            LatestEndsDate = upcomingMovies.Dates.UntilTo;

            foreach (var movie in FullDescription)
            {
                movie.PosterUrl = new System.Uri(_imageUrl.CreatePosterLink(movie.PosterPath));
            }

            ShortDescription = new ObservableCollection<IMovieIntro>(FullDescription.Take(5));
        }

        public void GetTopRatedMovies()
        {
            var topRated = new GetTopRatedMovies();
            var topMovies = topRated.GetTopMovies();
            _loadMore = new LoadMore(topRated.GetTopMovies);

            FullDescription = new ObservableCollection<MovieShort>(topMovies);

            foreach (var movie in FullDescription)
            {
                movie.PosterUrl = new System.Uri(_imageUrl.CreatePosterLink(movie.PosterPath));
            }

            ShortDescription = new ObservableCollection<IMovieIntro>(FullDescription.Take(5));
        }

        public void GetPopularMovies()
        {
            var popularMovie = new GetPopularMovies();
            var popularMovies = popularMovie.GetMovies();
            _loadMore = new LoadMore(popularMovie.GetMovies);

            FullDescription = new ObservableCollection<MovieShort>(popularMovies);

            foreach (var movie in FullDescription)
            {
                movie.PosterUrl = new System.Uri(_imageUrl.CreatePosterLink(movie.PosterPath));
            }

            ShortDescription = new ObservableCollection<IMovieIntro>(FullDescription.Take(5));
        }

        private async void ShowMoreClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new MovieScrollList(FullDescription, _loadMore));
        }
    }
}