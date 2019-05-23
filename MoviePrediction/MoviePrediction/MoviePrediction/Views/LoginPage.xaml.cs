using MoviePrediction.CustomViews;
using MoviePrediction.Services.Database;
using Rg.Plugins.Popup.Services;
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

            HelpLabel.GestureRecognizers.Add(new TapGestureRecognizer(async (s, e) =>
            {
                try
                {
                    await PopupNavigation.Instance.PushAsync(new Rg.Plugins.Popup.Pages.PopupPage());

                    await Navigation.PushAsync(new HelpView());
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Warning", ex.Message, "Confirm", "Cancel");
                }
                finally
                {
                    await PopupNavigation.Instance.PopAsync();
                }                
            }));

            SignUpLabel.GestureRecognizers.Add(new TapGestureRecognizer(async (s, e) =>
            {
                await Navigation.PushAsync(new Registration());
            }));
        }

        private async void PredixLoginBtn_Clicked(object sender, EventArgs e)
        {
            var email = emailInput.Text;
            var pwd = pwdInput.Text;

            if (email != null && pwd != null)
            {
                var registerCommand = new DbFirebase();

                try
                {
                    await PopupNavigation.Instance.PushAsync(new PopupLoading());

                    var token = await registerCommand.SignIn(email, pwd);

                    if (token != null)
                    {
                        await Application.Current.SavePropertiesAsync();
                        await Navigation.PushAsync(new MainPage());                        
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

        private async void ClickedOnTheLink(object sender, EventArgs e)
        {
            try
            {
                await PopupNavigation.Instance.PushAsync(new Rg.Plugins.Popup.Pages.PopupPage());

                await Navigation.PushAsync(new HelpView());
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
}