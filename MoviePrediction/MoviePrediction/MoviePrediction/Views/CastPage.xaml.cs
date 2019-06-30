using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviePrediction.ViewModels;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CastPage : ContentPage
	{
		public CastPage ()
		{
			InitializeComponent();
			BindingContext = new CastPageViewModel(new PageService());
		}
	}
}