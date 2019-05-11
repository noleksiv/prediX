using MoviePrediction.Models;
using MoviePrediction.Services.Photo;
using MoviePrediction.Services.Popular;
using MoviePrediction.Services.TopRated;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TVPage : ContentPage
	{
        private ImageUrl _imageUrl;

        public ObservableCollection<IMovieIntro> PopularTV { get; set; }
        public ObservableCollection<IMovieIntro> TopRatedTV { get; set; }

        public TVPage ()
		{
			InitializeComponent();
            FillInPage();
            this.BindingContext = this;
        }

        public void FillInPage()
        {
            _imageUrl = new ImageUrl();

            ContentForPopularTV();
            ContentForTopRaterdTV();
        }

        public async void ContentForPopularTV()
        {
            var popularTV = new GetPopularTV();
            var tvList = await popularTV.GetTVAsync();
            PopularTV =  new ObservableCollection<IMovieIntro>(tvList);

            foreach (var tv in PopularTV)
            {
                tv.PosterUrl = new Uri(_imageUrl.CreatePosterLink(tv.PosterPath));
            }
        }

        public async void ContentForTopRaterdTV()
        {
            var topRatedTV = new GetTopRatedTV();
            var tvList = await topRatedTV.GetTopTVAsync();

            TopRatedTV = new ObservableCollection<IMovieIntro>(tvList);

            foreach (var tv in TopRatedTV)
            {
                tv.PosterUrl = new Uri(_imageUrl.CreatePosterLink(tv.PosterPath));
            }
        }
    }
}