using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MoviePrediction.Models;
using MoviePrediction.Services.CastAndCrew;
using MoviePrediction.Views;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public class PredictionResultViewModel: ViewModelBase
    {
        private const int _maxCounter = 10;
        private IPageService _pageService;

        public double PredictionRate { get; set; }
        public string Title { get; set; }

        public ICommand GoHomePageCommand { get; private set; }

        public PredictionResultViewModel(MovieShort movie, IPageService pageService)
        {
            _pageService = pageService;
            GoHomePageCommand = new Command(async () => await GoToHomePage());

            Pageinitialization(movie);
        }

        public void Pageinitialization(MovieShort movie)
        {
            Title = movie.Title;
            Task.Run(async () => { PredictionRate = await Prediction(movie); }).Wait();
        }

        private async Task<double> Prediction(MovieShort movie)
        {
            var credits = new GetCastAndCrew(movie.Id);
            var castList = credits.GetCredits();
            var countToTake = castList.Cast.Count > _maxCounter ? _maxCounter : castList.Cast.Count;
            var rateAvg = 0D;

            return await Task.Run(() => 
            {
                foreach (var cast in castList.Cast.Take(countToTake))
                {
                    var person = new GetProfileInfo(cast.Id);
                    var resume = person.GetHistory();
                    rateAvg += resume.Cast.Select(i => i.VoteAverage).Average();
                }

                rateAvg = rateAvg / countToTake;

                return Math.Round(rateAvg, 2);
            });
           
        }

        private async Task GoToHomePage()
        {
            await _pageService.PushAsync(new HomePage());
        }
    }
}
