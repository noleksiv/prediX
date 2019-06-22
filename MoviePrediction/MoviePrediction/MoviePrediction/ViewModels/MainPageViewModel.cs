using MoviePrediction.Convertors;
using MoviePrediction.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public class MainPageViewModel: ViewModelBase
    {
        public ICommand UsersIconCommand { protected set; get; }
        public ICommand SearchIconCommand { protected set; get; }
        public ICommand HomePageCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        public MainPageViewModel()
        {
            UsersIconCommand = new Command(UsersIconClicked);
            SearchIconCommand = new Command(SearchIconClicked);
            HomePageCommand = new Command(GoToMainPage);
        }

        private async void UsersIconClicked()
        {
            await Navigation.PushAsync(new UsersPage());
        }

        private async void GoToMainPage()
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void SearchIconClicked()
        {
            try
            {
                await PopupNavigation.Instance.PushAsync(new Rg.Plugins.Popup.Pages.PopupPage());
                await Navigation.PushAsync(new HelpView("https://www.imdb.com/"));
            }
            catch (Exception)
            {

            }
            finally
            {
                await PopupNavigation.Instance.PopAsync();
            }
        }
    }
}
