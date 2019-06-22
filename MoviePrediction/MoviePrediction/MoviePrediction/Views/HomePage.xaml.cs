using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MoviePrediction.ViewModels;

namespace MoviePrediction.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePageViewModel ViewModel
        {
            get => BindingContext as HomePageViewModel;
            set => BindingContext = value;
        }

        public HomePage()
        {
            // TODO: clearing a navigation stack
            InitializeComponent();
            ViewModel = new HomePageViewModel(new PageService());
        }

        private void OnMovieSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.ItemSelectedCommand.Execute(e.SelectedItem);
        }
    }
}