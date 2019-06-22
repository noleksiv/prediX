using AutoMapper;
using MoviePrediction.Convertors;
using MoviePrediction.Models;
using MoviePrediction.Services.CastAndCrew;
using MoviePrediction.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MoviePrediction.ViewModels
{
    public class MovieInfoViewModel : ViewModelBase
    {
        private readonly IPageService _pageService;

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
                return result.Remove(result.Length - 2);
            }
        }
        public ObservableCollection<Cast> Cast { get; set; }
        public ObservableCollection<Crew> Crew { get; set; }
        public MovieShort FilmInfo { get; set; }

        public MovieInfoViewModel(MovieShort movieIntro)
        {
            FilmInfo = movieIntro;

            var movie = Mapper.Map<HistoryPreview>(movieIntro);
            App.Database.SaveItem(movie);

            GetMovieCredits(FilmInfo.Id);
        }

        public MovieInfoViewModel(MovieShort movieIntro, IPageService pageService): this(movieIntro)
        {
            _pageService = pageService;          
        }

        public void GetMovieCredits(int movieId)
        {
            var castAndCrew = new GetCastAndCrew(movieId);
            var castInfo = castAndCrew.GetCredits();

            // IEnumerable to ObservableCollection
            Cast = new ObservableCollection<Cast>(castInfo.Cast.DistinctBy(i => i.Name));
            Crew = new ObservableCollection<Crew>(castInfo.Crew.DistinctBy(i => i.Name));
        }

        private async void GoToMainPage()
        {
            await _pageService?.PushAsync(new HomePage());
        }
    }
}
