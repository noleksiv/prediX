using AutoMapper;
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
using MoviePrediction.Convertors;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieInfo : ContentPage
	{       
        private ImageUrl _imageUrl;
        public string Genres
        {
            get
            {
                var genreStr = new StringBuilder();
                foreach (var genre in FilmInfo.GenreIds)
                {
                    genreStr.Append(Genre.NameOfGenre(genre) + ", ");
                }

                var result = genreStr.ToString();
                return result.Remove(result.Length-2);
            }
        }
        public ObservableCollection<Cast> Cast { get; set; }
        public ObservableCollection<Crew> Crew { get; set; }
        public MovieShort FilmInfo { get; set; }

        public MovieInfo ()
		{
			InitializeComponent ();
            _imageUrl = new ImageUrl();
		}

        public MovieInfo(MovieShort movieIntro) : this()
        {
            FilmInfo = movieIntro;
            FilmInfo.BackdropUrl = new Uri(_imageUrl.CreateBackdropLink(FilmInfo.BackdropPath));

            var movie = Mapper.Map<HistoryPreview>(movieIntro);
            App.Database.SaveItem(movie);

            GetMovieCredits(FilmInfo.Id);
            this.BindingContext = this;
        }

        public void GetMovieCredits(int movieId)
        {
            var castAndCrew = new GetCastAndCrew(movieId);
            var castInfo = castAndCrew.GetCredits();

            // IEnumerable to ObservableCollection
            Cast = new ObservableCollection<Cast>(castInfo.Cast.DistinctBy(i=>i.Name));
            Crew = new ObservableCollection<Crew>(castInfo.Crew.DistinctBy(i => i.Name));

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