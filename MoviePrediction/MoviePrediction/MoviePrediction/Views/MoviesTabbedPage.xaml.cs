using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BottomBar.XamarinForms;

namespace MoviePrediction.Views
{
    public enum MovieTap
    {
        Latest,
        Upcoming,
        Popular,
        Toprated
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesTabbedPage : BottomBarPage
    {
        public MoviesTabbedPage ()
        {
            //Children.Add(new MoviesPage(MovieTap.Latest) { Title = "1", Icon = "exit.png" });
            //Children.Add(new MoviesPage(MovieTap.Upcoming) { Title = "2", Icon = "exit.png" });
            //Children.Add(new MoviesPage(MovieTap.Popular) { Title = "3", Icon = "exit.png" });
            //Children.Add(new MoviesPage(MovieTap.Toprated) { Icon = "exit.png", Title = "1" });

            InitializeComponent();           
        }
    }
}