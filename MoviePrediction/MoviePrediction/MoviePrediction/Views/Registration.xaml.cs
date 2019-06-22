using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviePrediction.ViewModels;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Registration : ContentPage
	{
		public Registration ()
		{
			InitializeComponent();
			BindingContext = new RegistrationPageViewModel(new PageService());
		}     
	}
}