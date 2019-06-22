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
using MoviePrediction.ViewModels;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieInfo : ContentPage
	{
		public MovieInfo ()
		{
			InitializeComponent ();            
		}

		public MovieInfo(MovieShort movieIntro) : this()
		{
			BindingContext = new MovieInfoViewModel(movieIntro, new PageService());
		}        
	}
}