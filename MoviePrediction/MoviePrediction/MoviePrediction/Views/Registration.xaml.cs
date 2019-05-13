using MoviePrediction.Services.Database;
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

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            var email = emailInput.Text;
            var pwd = pwdInput.Text;

            if (email!=null && pwd != null)
            {
                var registerCommand = new DbFirebase();
                try
                {
                    var token = await registerCommand.SignUp(email, pwd);

                    if (token != null)
                    {
                        await Navigation.PushAsync(new MainPage());
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Warning", ex.Message, "Confirm", "Cancel");
                }
            }
        }

        private async void SignInClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void HelpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpView());
        }
    }
}