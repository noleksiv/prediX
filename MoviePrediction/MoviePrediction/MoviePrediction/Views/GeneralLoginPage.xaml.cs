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
	public partial class GeneralLoginPage : ContentPage
	{

        public GeneralLoginPage ()
		{
			InitializeComponent();
            Navigation.NavigationStack.ToList().Clear();
        }

        private async void LoginPageClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void PredixLoginBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}