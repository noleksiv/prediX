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
	public partial class Registration : ContentPage
	{
		public Registration ()
		{
            InitializeComponent ();
        }

        private async void ClickedOnTheLink(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpView());
        }
    }
}