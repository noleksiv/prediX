using System;
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
using MoviePrediction.Services.Database;
using Rg.Plugins.Popup.Services;
using MoviePrediction.CustomViews;

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

        public async void FillInPage()
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

        private async void TrendingListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            try
            {
                await PopupNavigation.Instance.PushAsync(new PopupLoading());

                var selectedItem = ((ListView)sender).SelectedItem;
                var movie = selectedItem as MovieShort;

                // connection to Firebase
                //var db = new DbFirebase();
                //await db.AddToHistory(movie);

                await Navigation.PushAsync(new MovieInfo(movie));

                trendingListView.SelectedItem = null;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                await PopupNavigation.Instance.PopAsync();
            }            
        }
    }
}