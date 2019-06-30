using MoviePrediction.CustomViews;
using MoviePrediction.Resources;
using MoviePrediction.Services.Database;
using MoviePrediction.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public class RegistrationPageViewModel : ViewModelBase
    {
        private string _email;
        private string _password;
        private IPageService _pageService;

        public string Email
        {
            get { return _email; }
            set
            {
                SetValue(ref _email, value);
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                SetValue(ref _password, value);
            }
        }

        public ICommand SignUpCommand { get; private set; }
        public ICommand SignInCommand { get; private set; }
        public ICommand HelpLinkCommand { get; private set; }

        public RegistrationPageViewModel(IPageService pageService)
        {
            _pageService = pageService;

            SignUpCommand = new Command(async () => await SignInPredix());
            SignInCommand = new Command(async () => await ClickedOnTheLink(new LoginPage()));
            HelpLinkCommand = new Command(async () => await ClickedOnTheLink(new HelpView()));            
        }

        private async Task SignInPredix()
        {

            if (Email == null || Password == null)
                return;

            var registerCommand = new DbFirebase();

            try
            {
                await _pageService.PushAsync(new PopupLoading());

                var token = await registerCommand.SignUp(Email, Password);

                if (token != null)
                {
                    await _pageService.PushAsync(new LoginPage());
                }
            }
            catch (Exception ex)
            {
                await _pageService.DisplayAlert(AppResources.WarningTitle, ex.Message);
            }
            finally
            {
                await _pageService.PopAsync();
            }


        }

        private async Task ClickedOnTheLink(Page page)
        {
            try
            {
                await _pageService.PushAsync(new Rg.Plugins.Popup.Pages.PopupPage());

                await _pageService.PushAsync(page);
            }
            catch (Exception ex)
            {
                await _pageService.DisplayAlert(AppResources.WarningTitle, ex.Message);
            }
            finally
            {
                await _pageService.PopAsync();
            }

        }
    }
}
