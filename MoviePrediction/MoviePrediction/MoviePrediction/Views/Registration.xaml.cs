using MoviePrediction.CustomViews;
using MoviePrediction.Services.Database;
using Rg.Plugins.Popup.Services;
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
                    await PopupNavigation.Instance.PushAsync(new PopupLoading());

                    var token = await registerCommand.SignUp(email, pwd);

                    if (token != null)
                    {
                        await Navigation.PushAsync(new LoginPage());
                    }
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Warning", ex.Message, "Confirm", "Cancel");
                }
                finally
                {
                    await PopupNavigation.Instance.PopAsync();
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