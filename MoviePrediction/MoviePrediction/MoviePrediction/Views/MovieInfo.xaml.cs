using MoviePrediction.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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