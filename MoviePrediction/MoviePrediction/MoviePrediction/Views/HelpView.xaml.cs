using MoviePrediction.Helpers;
using MoviePrediction.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HelpView : ContentPage
	{
		public HelpView(string url = LinksContainer.HelpCenter)
		{
			InitializeComponent();
			BindingContext = new HelpPageViewModel(url, new PageService());
		}
	}
}