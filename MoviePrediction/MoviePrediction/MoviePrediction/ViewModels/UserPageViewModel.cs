using MoviePrediction.Helpers;
using MoviePrediction.Models;
using MoviePrediction.Views;
using System.Collections.ObjectModel;
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
            Application.Current.Properties.Remove(ApplicationProperties.SessionId);
            Application.Current.Properties.Remove(ApplicationProperties.UserId);

            await Application.Current.SavePropertiesAsync();

            await _pageService.PushAsync(new LoginPage());
        }
    }
}
