using MoviePrediction.Resources;
using MoviePrediction.ViewModels;
using Rg.Plugins.Popup.Pages;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.CustomViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PopupLoading : PopupPage
	{
		public PopupLoading (string caption = null)
		{
			InitializeComponent ();
            BindingContext = new PopupLoadingViewModel(caption);
		}		
	}
}