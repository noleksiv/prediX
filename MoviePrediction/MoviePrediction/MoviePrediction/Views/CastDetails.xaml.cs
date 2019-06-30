using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviePrediction.Models;
using MoviePrediction.ViewModels;

namespace MoviePrediction.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CastDetails : ContentPage
    {

        public CastDetails()
        {
            InitializeComponent();
        }

        public CastDetails(People human) : this()
        {
            BindingContext = new CastDetailsViewModel(human, new PageService());
        }      
    }
}