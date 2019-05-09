using MoviePrediction.Models;
using MoviePrediction.Services.CastAndCrew;
using MoviePrediction.Services.Photo;
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
	public partial class MovieInfo : ContentPage
	{       
        private ImageUrl _imageUrl;

        public ObservableCollection<Cast> Cast { get; set; }
        public ObservableCollection<Crew> Crew { get; set; }
        public IMovieIntro FilmInfo { get; set; }

        public MovieInfo ()
		{
			InitializeComponent ();
            _imageUrl = new ImageUrl();
		}

        public MovieInfo(IMovieIntro movieIntro) : this()
        {
            FilmInfo = movieIntro;
            FilmInfo.BackdropUrl = new Uri(_imageUrl.CreateBackdropLink(FilmInfo.BackdropPath));
            GetMovieCredits(FilmInfo.Id);
            this.BindingContext = this;
        }

        public void GetMovieCredits(int movieId)
        {
            var castAndCrew = new GetCastAndCrew(movieId);
            var castInfo = castAndCrew.GetCredits();

            // IEnumerable to ObservableCollection
            Cast = new ObservableCollection<Cast>(castInfo.Cast);
            Crew = new ObservableCollection<Crew>(castInfo.Crew);

            foreach (var person in Cast)
            {
                person.ProfileUrl = new Uri(_imageUrl.CreatePosterLink(person.ProfilePath));
            }
            foreach (var person in Crew)
            {
                person.ProfileUrl = new Uri(_imageUrl.CreatePosterLink(person.ProfilePath));
            }
        }
    }
}