using MoviePrediction.Convertors;
using MoviePrediction.Models;
using MoviePrediction.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            BindingContext = new MainPageViewModel { Navigation = this.Navigation };            
        }        
    }
}