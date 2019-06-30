using MoviePrediction.Models;
using MoviePrediction.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
	public delegate IList<MovieShort> LoadMore(int pageNumber);

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviesPage : ContentPage
	{
		public MoviesPageViewModel ViewModel
		{
			get => BindingContext as MoviesPageViewModel;
			set => BindingContext = value;
		}

		public MoviesPage()
		{
			InitializeComponent();
		}

		public MoviesPage (MovieTap tap, IPageService pageService) : this()
		{
			ViewModel = new MoviesPageViewModel(tap, pageService);
		}
	}
}