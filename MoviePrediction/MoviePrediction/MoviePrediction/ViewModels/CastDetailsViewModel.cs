using Microcharts;
using MoviePrediction.Expansions;
using MoviePrediction.Models;
using MoviePrediction.Resources;
using MoviePrediction.Services.CastAndCrew;
using MoviePrediction.Views;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MoviePrediction.ViewModels
{
    public class CastDetailsViewModel: ViewModelBase
    {
        private const int _maxMovies = 10;
        private readonly IPageService _pageService;
        private Chart _barchart;
        private Chart _circlechart;

        public Uri ImageLink { get; set; }
        public PersonProfile Info { get; set; }
        public PersonResume Movies { get; set; }
        public Chart BarChart
        {
            get
            {
                return _barchart;
            }
            set
            {
                SetValue(ref _barchart, value);
            }

        }
        public Chart CircleChart
        {
            get
            {
                return _circlechart;
            }
            set
            {
                SetValue(ref _circlechart, value);
            }
        }

        public ICommand GoToProfileCommand { get; private set; }
        public ICommand GoHomePageCommand { get; private set; }

        public CastDetailsViewModel()
        {
            BarChart = new BarChart();
            CircleChart = new DonutChart() { LabelTextSize = 14 };

            GoToProfileCommand = new Xamarin.Forms.Command(async () => await GoToImdbProfile());
            GoHomePageCommand = new Xamarin.Forms.Command(async () => await GoToMainPage());
        }

        public CastDetailsViewModel(People human, IPageService pageService) : this()
        {
            _pageService = pageService;
            FillInPage(human);
        }

        private void FillInPage(People human)
        {
            var bioInfo = new ProfileInfo(human.Id);
            Info = bioInfo.GetInfo();
            ImageLink = new Uri(Info.ProfilePath);

            Movies = bioInfo.GetHistory();

            var topList = BuildBarDiagram();
            var circleList = BuildCircleDiagram();

            BarChart.Entries = topList;
            CircleChart.Entries = circleList;
        }

        private List<Entry> BuildBarDiagram()
        {
            var random = new Random();
            var colorGenerator = new ColorGenerator();
            var TopEntries = new List<Entry>();

            var numberToTake = Movies.Cast.Count > _maxMovies ? _maxMovies : Movies.Cast.Count;           

            foreach (var movie in Movies.Cast.Take(numberToTake))
            {

                TopEntries.Add(new Entry((float)movie.VoteAverage)
                {
                    Label = movie.Title,
                    ValueLabel = movie.VoteAverage.ToString(),
                    Color = SKColor.Parse(colorGenerator.GenerateColor(random))
                });
            }
            return TopEntries;
        }

        private List<Entry> BuildCircleDiagram()
        {
            var random = new Random();
            var colorGenerator = new ColorGenerator();
            var entries = new List<Entry>();

            var numberToTake = Movies.Cast.Count > _maxMovies ? _maxMovies : Movies.Cast.Count;
            var genres = Movies.Cast.Select(g => g.GenreIds).SelectMany(g => g).ToList();           

            foreach (var genreId in genres.Distinct())
            {
                var uniqueNumbers = genres.Count(g => g == genreId);

                entries.Add(new Entry((float)uniqueNumbers)
                {
                    Label = Genre.NameOfGenre(genreId),
                    ValueLabel = uniqueNumbers.ToString(),
                    Color = SKColor.Parse(colorGenerator.GenerateColor(random))
                });
            }
            return entries;
        }       

        private async Task GoToMainPage()
        {
            await _pageService.PushAsync(new MainPage());
        }

        private async Task GoToImdbProfile()
        {
            try
            {
                await _pageService.PushAsync(new Rg.Plugins.Popup.Pages.PopupPage());
                await _pageService.PushAsync(new HelpView(Info.ProfileUrl));
            }
            catch (Exception ex)
            {
                await _pageService.DisplayAlert(AppResources.WarningTitle, ex.Message);
            }
            finally
            {
                await _pageService.PopAsync();
            }
        }
    }
}
