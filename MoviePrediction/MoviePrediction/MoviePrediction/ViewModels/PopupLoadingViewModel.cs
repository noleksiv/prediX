using MoviePrediction.Resources;

namespace MoviePrediction.ViewModels
{
    public class PopupLoadingViewModel:ViewModelBase
    {
        private string _caption;

        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                SetValue(ref _caption, value);
            }
        }

        public PopupLoadingViewModel(string caption = null)
        {
            Caption = caption ?? AppResources.LoadingTitle;
        }
    }
}
