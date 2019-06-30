using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BottomBar.XamarinForms;
using MoviePrediction.ViewModels;

namespace MoviePrediction.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesTabbedPage : BottomBarPage
    {
        public MoviesTabbedPage ()
        {
            InitializeComponent();

            FixedMode = true;
            BarTheme = BarThemeTypes.DarkWithAlpha;
            BarTextColor = Color.FromRgb(181, 13, 13); 

            BindingContext = new TabbedPageViewModel(Children);
        }
    }
}