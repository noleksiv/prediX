using MoviePrediction.Models;
using MoviePrediction.Services.NowPlaying;
using MoviePrediction.Services.Photo;
using MoviePrediction.Services.Popular;
using MoviePrediction.Services.TopRated;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviesPage : ContentPage
	{
        private ImageUrl _imageUrl;

        public string LatestStartDate { get; set; }
        public string LatestEndsDate { get; set; }
        public string PlayingDate { get => $"From {LatestStartDate} to {LatestEndsDate}"; }

        public ObservableCollection<IMovieIntro> LatestShort { get; set; }
        public ObservableCollection<IMovieIntro> Latest{ get; set; }

        public ObservableCollection<IMovieIntro> PopularShort { get; set; }
        public ObservableCollection<IMovieIntro> Popular { get; set; }


        public ObservableCollection<IMovieIntro> TopRatedShort { get; set; }
        public ObservableCollection<IMovieIntro> TopRated{ get; set; }

        public ObservableCollection<IMovieIntro> UpcomingShort { get; set; }
        public ObservableCollection<IMovieIntro> Upcoming { get; set; }

        public MoviesPage ()
		{
			InitializeComponent ();
            ReceiveContent();
            this.BindingContext = this;
        }

        private void ReceiveContent()
        {
            _imageUrl = new ImageUrl();
            GetLatestMovies();
            GetTopRatedMovies();
            GetPopularMovies();
        }

        private void GetLatestMovies()
        {
            var latest = new GetLatest();
            var latestMovies = latest.GetLatestMovies();

            var upcomingMovies = latest.GetUpcomingMovies();

            Latest = new ObservableCollection<IMovieIntro>(latestMovies.Movies);
            Upcoming = new ObservableCollection<IMovieIntro>(upcomingMovies.Movies);

            LatestStartDate = latestMovies.Dates.From;
            LatestEndsDate = latestMovies.Dates.UntilTo;

            foreach (var movie in Latest)
            {
                movie.PosterUrl = new System.Uri(_imageUrl.CreatePosterLink(movie.PosterPath));
            }
            foreach (var movie in Upcoming)
            {
                movie.PosterUrl = new System.Uri(_imageUrl.CreatePosterLink(movie.PosterPath));
            }

            LatestShort = new ObservableCollection<IMovieIntro>(Latest.Take(5));
            UpcomingShort = new ObservableCollection<IMovieIntro>(Upcoming.Take(5));
        }

        private void GetTopRatedMovies()
        {
            var topRated = new GetTopRatedMovies();
            var topMovies = topRated.GetTopMovies();

            TopRated = new ObservableCollection<IMovieIntro>(topMovies);

            foreach (var movie in TopRated)
            {
                movie.PosterUrl = new System.Uri(_imageUrl.CreatePosterLink(movie.PosterPath));
            }

            TopRatedShort = new ObservableCollection<IMovieIntro>(TopRated.Take(5));
        }

        private void GetPopularMovies()
        {
            var popularMovie = new GetPopularMovies();
            var popularMovies = popularMovie.GetMovies();

            Popular = new ObservableCollection<IMovieIntro>(popularMovies);

            foreach (var movie in Popular)
            {
                movie.PosterUrl = new System.Uri(_imageUrl.CreatePosterLink(movie.PosterPath));
            }

            PopularShort = new ObservableCollection<IMovieIntro>(Popular.Take(5));
        }

    }
}