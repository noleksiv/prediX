using MoviePrediction.Convertors;
using MoviePrediction.Models;
using MoviePrediction.Services.Photo;
using MoviePrediction.ViewModels;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new UserPageViewModel(new PageService());
        }
    }
}