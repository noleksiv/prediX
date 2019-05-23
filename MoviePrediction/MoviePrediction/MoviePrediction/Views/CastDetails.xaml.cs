using MoviePrediction.Models;
using MoviePrediction.Services.CastAndCrew;
using MoviePrediction.Services.Photo;
using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microcharts;
using SkiaSharp;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;
using System.Collections.ObjectModel;
using Rg.Plugins.Popup.Services;

namespace MoviePrediction.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CastDetails : ContentPage, INotifyPropertyChanged
    {
        public Uri ImageLink { get; set; }
        public PersonProfile Info { get; set; }
        public PersonResume Movies { get; set; }
        public Chart BarChart { get; set; }
        public Chart CircleChart { get; set; }

        public CastDetails()
        {
            InitializeComponent();
            BarChart = new BarChart();
            CircleChart = new DonutChart() { LabelTextSize=14};
            //TopEntries = new ObservableCollection<Entry>();
        }

        public CastDetails(People human) : this()
        {
            FillInPage(human);
            this.BindingContext = this;
        }

        private async void FillInPage(People human)
        {
            var imageUrl = new ImageUrl();

            var bioInfo = new GetProfileInfo(human.Id);
            Info = bioInfo.GetInfo();
            ImageLink = new Uri(imageUrl.CreatePosterLink(Info.ProfilePath));
            Info.ProfilePath = imageUrl.CreatePosterLink(Info.ProfilePath);

            Movies = bioInfo.GetHistory();

            foreach (var movie in Movies.Cast)
            {
                movie.PosterUrl = new Uri(imageUrl.CreatePosterLink(movie.PosterPath));
            }
            
            var topList = BuildBarDiagram();
            var circleList = BuildCircleDiagram();

            BarChart.Entries = topList;
            CircleChart.Entries = circleList;
        }

        private async void GoToImdb(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpView(Info.ProfileUrl));
        }

        private List<Entry> BuildBarDiagram()
        {
            var TopEntries = new List<Entry>();

            var numberToTake = Movies.Cast.Count > 10 ? 10 : Movies.Cast.Count;

            var random = new Random();

            foreach (var movie in Movies.Cast.Take(numberToTake))
            {               

                TopEntries.Add(new Entry((float)movie.VoteAverage)
                {
                    Label = movie.Title,
                    ValueLabel = movie.VoteAverage.ToString(),
                    Color = SKColor.Parse(ColorGenerator(random))
                });
            }
            return TopEntries;
        }

        private List<Entry> BuildCircleDiagram()
        {
            var entries = new List<Entry>();

            var numberToTake = Movies.Cast.Count > 10 ? 10 : Movies.Cast.Count;

            var genres = Movies.Cast.Select(g => g.GenreIds).SelectMany(g=>g).ToList();

            var random = new Random();

            foreach (var genreId in genres.Distinct())
            {
                var uniqueNumbers = genres.Count(g => g == genreId);
                entries.Add(new Entry((float)uniqueNumbers)
                {
                    Label = Genre.NameOfGenre(genreId),
                    ValueLabel = uniqueNumbers.ToString(),
                    Color = SKColor.Parse(ColorGenerator(random))
                });
            }
            return entries;
        }


        private string ColorGenerator(Random random)
        {
            var numbers = "0123456789";
            var chars = "abcdef";

            var color = new StringBuilder("#");

            for (var i = 1; i <= 6; i++)
            {
                var boolean = random.Next(0, 2);
                if (boolean == 0)
                {
                    color.Append(numbers[random.Next(0, numbers.Length)]);

                }
                else
                {
                    color.Append(chars[random.Next(0, chars.Length)]);
                }
            }

            return color.ToString();
        }

        private async void GoToMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void GoToImdbProfile(object sender, EventArgs e)
        {
            try
            {
                await PopupNavigation.Instance.PushAsync(new Rg.Plugins.Popup.Pages.PopupPage());
                await Navigation.PushAsync(new HelpView($"https://www.imdb.com/name/{Info.ImdbId}/"));
            }
            catch (Exception)
            {

            }
            finally
            {
                await PopupNavigation.Instance.PopAsync();
            }
        }
    }
}