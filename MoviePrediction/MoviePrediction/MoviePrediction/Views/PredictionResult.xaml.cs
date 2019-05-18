using MoviePrediction.Models;
using MoviePrediction.Services.CastAndCrew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PredictionResult : ContentPage
	{
        public double PredictionRate { get; set; }
        public string Title { get; set; }

        public PredictionResult ()
		{
			InitializeComponent ();
		}

        public PredictionResult(MovieShort movie) : this()
        {
            Title = movie.Title;
            PredictionRate = Prediction(movie);
            this.BindingContext = this;
        }

        private double Prediction(MovieShort movie)
        {
            var credits = new GetCastAndCrew(movie.Id);
           
            var castList = credits.GetCredits();

            var countToTake = castList.Cast.Count > 15 ? 15 : castList.Cast.Count;

            var rateAvg = 0D;

            foreach (var cast in castList.Cast.Take(countToTake))
            {
                var person = new GetProfileInfo(cast.Id);
                var resume = person.GetHistory();
                rateAvg += resume.Cast.Select(i => i.VoteAverage).Average();
            }

            rateAvg = rateAvg / countToTake + 1;

            return Math.Round(rateAvg,2);
        }
	}
}