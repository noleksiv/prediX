using MoviePrediction.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public class HelpPageViewModel
    {
        private IPageService _pageService;

        public string RedirectUrl { get; set; }
        public ICommand BrowseCommand { get; private set; }

        public HelpPageViewModel(string url, IPageService pageService)
        {
            _pageService = pageService;
            RedirectUrl = url;

            BrowseCommand = new Command(async () => await GoToMainPage());
        }

        private async Task GoToMainPage()
        {
            await _pageService.PushAsync(new MainPage());
        }
    }
}
