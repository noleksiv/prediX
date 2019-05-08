using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

            // actions for the label clicks
            //HelpLabel.GestureRecognizers.Add(new TapGestureRecognizer(async (s,e) => 
            //{
            //    await Navigation.PushAsync(new HelpView());               
            //}));

            //SignUpLabel.GestureRecognizers.Add(new TapGestureRecognizer(async (s, e) => 
            //{
            //    await Navigation.PushAsync(new Registration());
            //}));
        }

        private void PredixLoginBtn_Clicked(object sender, EventArgs e)
        {

        }

        private async void ClickedOnTheLink(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpView());
        }
    }
}