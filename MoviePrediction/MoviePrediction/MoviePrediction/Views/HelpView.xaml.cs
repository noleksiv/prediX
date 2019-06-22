using MoviePrediction.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HelpView : ContentPage
	{

		public HelpView ()
		{
			InitializeComponent ();
		}

		public HelpView(string url = "https://help.netflix.com/en/") : this()
		{
			InitializeComponent();
			BindingContext = new HelpPageViewModel(url, new PageService());
		}
	}
}