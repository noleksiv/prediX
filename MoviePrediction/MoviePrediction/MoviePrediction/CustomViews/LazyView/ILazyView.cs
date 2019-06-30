using Xamarin.Forms;

namespace MoviePrediction.CustomViews
{
    public interface ILazyView
    {
        View Content { get; set; }
        Color AccentColor { get; }
        bool IsLoaded { get; }
        void LoadView();
    }
}
