using MoviePrediction.Models;
using MoviePrediction.Services.CastAndCrew;
using MoviePrediction.ViewModels;
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

		public PredictionResult ()
		{
			InitializeComponent ();            
		}

        public PredictionResult(MovieShort movie): this()
        {
            BindingContext = new PredictionResultViewModel(movie, new PageService());
        }
	}
}