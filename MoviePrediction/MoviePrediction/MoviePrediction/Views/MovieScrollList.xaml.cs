using MoviePrediction.Models;
using MoviePrediction.ViewModels;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieScrollList : ContentPage
    {
        public ScrollListViewModel ViewModel
        {
            get => BindingContext as ScrollListViewModel;
            set => BindingContext = value;
        }

        public MovieScrollList()
        {
            InitializeComponent();
        }

        public MovieScrollList(ObservableCollection<MovieShort> moviesList, LoadMore loadMethod, IPageService pageService) : this()
        {
            ViewModel = new ScrollListViewModel(moviesList, loadMethod, pageService);
        }

        public MovieScrollList(ObservableCollection<MovieShort> moviesList, LoadMore loadMethod) : this(moviesList, loadMethod, new PageService())  {}
    }
}