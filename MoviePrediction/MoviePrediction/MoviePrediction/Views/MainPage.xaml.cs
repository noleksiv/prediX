using MoviePrediction.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage ()
        {
            InitializeComponent();           

            BindingContext = new MainPageViewModel(new PageService());
        }        
    }
}