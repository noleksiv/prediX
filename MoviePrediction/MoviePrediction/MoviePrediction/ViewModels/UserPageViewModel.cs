using MoviePrediction.Convertors;
using MoviePrediction.Models;
using MoviePrediction.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public class UserPageViewModel
    {
        private IPageService _pageService;

        public string UserIcon { get; set; }
        public ObservableCollection<HistoryPreview> History { get; set; }
        public ICommand LogOutCommand { get; private set; }

        public UserPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            LogOutCommand = new Command(async() => await LogOutClicked());

            FillPage();
        }

        private void FillPage()
        {
            var history = App.Database.GetItems();
            History = new ObservableCollection<HistoryPreview>(history);
        }

        private async Task LogOutClicked()
        {
            Application.Current.Properties.Remove("SessionId");
            Application.Current.Properties.Remove("Uid");

            await Application.Current.SavePropertiesAsync();

            await _pageService.PushAsync(new LoginPage());
        }
    }
}
