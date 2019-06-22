using MoviePrediction.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();

			BindingContext = new LoginPageViewModel(new PageService());			
		}
	}
}