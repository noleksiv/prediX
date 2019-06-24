using MoviePrediction.CustomViews;
using MoviePrediction.Resources;
using MoviePrediction.Services.Database;
using MoviePrediction.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public class LoginPageViewModel: ViewModelBase
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

        public ICommand LoginCommand { get; private set; }
        public ICommand LinkCommand { get; private set; }
        public ICommand SignUpCommand { get; private set; }

        public LoginPageViewModel(IPageService pageService)
        {
            _pageService = pageService;

            LoginCommand = new Command(async () => await PredixLogin());
            LinkCommand = new Command(async() => await ClickedOnTheLink(new HelpView()));
            SignUpCommand = new Command(async() => await ClickedOnTheLink(new Registration()));
        }

        private async Task PredixLogin()
        {

            if (Email == null || Password == null)
                return;
           
            var registerCommand = new DbFirebase();

            try
            {
                await _pageService.PushAsync(new PopupLoading());

                var token = await registerCommand.SignIn(Email, Password);

                if (token != null)
                {
                    await Application.Current.SavePropertiesAsync();
                    await _pageService.PushAsync(new MainPage());
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
