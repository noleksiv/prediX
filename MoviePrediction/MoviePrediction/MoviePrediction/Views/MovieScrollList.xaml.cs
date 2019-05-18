using MoviePrediction.Models;
using MoviePrediction.Services.Photo;
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

               var movies = LoadMoreMovies();

               return movies;
           };

            //FillInPage();
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

            var selectedItem = ((ListView)sender).SelectedItem;
            var movie = selectedItem as MovieShort;

            // connection to Firebase
            //var db = new DbFirebase();
            //await db.AddToHistory(movie);

            await Navigation.PushAsync(new MovieInfo(movie));
        }
    }
}