using MoviePrediction.Models;
using MoviePrediction.Services.Photo;
using MoviePrediction.Services.Popular;
using MoviePrediction.Services.TopRated;
using MoviePrediction.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TVPage : ContentPage
    {
        public TVPage()
        {
            InitializeComponent();
            this.BindingContext = new TVPageViewModel();
        }     
    }
}