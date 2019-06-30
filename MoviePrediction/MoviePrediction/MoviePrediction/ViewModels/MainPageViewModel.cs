using MoviePrediction.Helpers;
using MoviePrediction.Resources;
using MoviePrediction.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public class MainPageViewModel: ViewModelBase
    {
        private readonly IPageService _pageService;

        public ICommand UsersIconCommand { protected set; get; }
        public ICommand SearchIconCommand { protected set; get; }
        public ICommand HomePageCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        public MainPageViewModel(IPageService pageService)
        {
            _pageService = pageService;

            UsersIconCommand = new Command(UsersIconClicked);
            SearchIconCommand = new Command(SearchIconClicked);
            HomePageCommand = new Command(GoToMainPage);
        }

        private async void UsersIconClicked()
        {
            await _pageService.PushAsync(new UsersPage());
        }

        private async void GoToMainPage()
        {
            await _pageService.PushAsync(new MainPage());
        }

        private async void SearchIconClicked()
        {
            try
            {
                await _pageService.PushAsync(new Rg.Plugins.Popup.Pages.PopupPage());
                await _pageService.PushAsync(new HelpView(LinksContainer.Imdb));
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
