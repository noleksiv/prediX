using MoviePrediction.CustomViews;
using MoviePrediction.Models;
using MoviePrediction.Services.NowPlaying;
using MoviePrediction.Services.Photo;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
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
	public partial class PredictionPage : ContentPage
	{
        private bool _isBusy;
        private readonly int _moviesOnPage = 20;
        private ImageUrl imageUrl = new ImageUrl();

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


        public PredictionPage()
        {
            InitializeComponent();

            Movie = new InfiniteScrollCollection<MovieShort>();

            Movie.OnLoadMore = async () =>
            {
                IsBusy = true;

                return await Task.Run(() =>
                {
                    var movies = LoadMoreMovies();
                    return movies;
                });                
            };

            Movie.AddRange(LoadMoreMovies("ua"));
            this.BindingContext = this;
        }

        private IList<MovieShort> LoadMoreMovies(string region = null)
        {
            var latest = new GetLatest();
            var page = Movie.Count / _moviesOnPage;
            var movies = latest.GetUpcomingMovies(page+1, region);

            foreach (var human in movies)
            {
                human.PosterUrl = new Uri(imageUrl.CreatePosterLink(human.PosterPath));
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
                await PopupNavigation.Instance.PushAsync(new PopupLoading("Wait for prediction..."));

                var selectedItem = ((ListView)sender).SelectedItem;
                var movie = selectedItem as MovieShort;

                await Navigation.PushAsync(new PredictionResult(movie));
            }
            catch (Exception ex)
            {
                await DisplayAlert("Warning", ex.Message, "Confirm", "Cancel");
            }
            finally
            {
                shotrListView.SelectedItem = null;
                await PopupNavigation.Instance.PopAsync();
            }
        }       
	}
}