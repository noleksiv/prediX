using Xamarin.Forms;

namespace MoviePrediction.CustomViews
{
    public interface ILoadingPageService
    {
        void InitLoadingPage(ContentPage loadingIndicatorPage = null);
        void ShowLoadingPage();
        void HideLoadingPage();
    }
}
