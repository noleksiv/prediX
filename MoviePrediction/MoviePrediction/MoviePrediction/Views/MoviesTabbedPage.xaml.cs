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
            InitializeComponent();

            this.FixedMode = true;
            this.BarTheme = BarThemeTypes.DarkWithAlpha;
            this.BarTextColor = Color.FromRgb(181, 13, 13);

            Children.Add(new MoviesPage(MovieTap.Latest)
            {
                Icon = "LATEST.png"
            });

            Children.Add(new MoviesPage(MovieTap.Upcoming)
            {
                Icon = "upcoming.png"
            });

            Children.Add(new MoviesPage(MovieTap.Popular)
            {
                Icon = "popular.png"
            });

            Children.Add(new MoviesPage(MovieTap.Toprated)
            {
                Icon = "topRated.png"
            });            
        }
    }
}