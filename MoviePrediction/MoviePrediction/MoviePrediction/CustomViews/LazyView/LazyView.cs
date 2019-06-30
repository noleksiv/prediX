using Xamarin.Forms;

namespace MoviePrediction.CustomViews
{
    public class LazyView<TView> : ALazyView where TView : View, new()
    {
        public override void LoadView()
        {
            IsLoaded = true;
            View view = new TView { BindingContext = BindingContext };
            Content = view;
        }
    }
}
