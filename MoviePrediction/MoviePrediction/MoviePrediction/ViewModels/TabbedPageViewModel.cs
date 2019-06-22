using MoviePrediction.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public enum MovieTap
    {
        Latest,
        Upcoming,
        Popular,
        Toprated
    }

    public class TabbedPageViewModel
    {
        public TabbedPageViewModel(IList<Page> page)
        {
            var pageService = new PageService();

            page.Add(new MoviesPage(MovieTap.Latest, pageService)
            {
                Icon = "LATEST.png",

            });

            page.Add(new MoviesPage(MovieTap.Upcoming, pageService)
            {
                Icon = "upcoming.png"
            });

            page.Add(new MoviesPage(MovieTap.Popular, pageService)
            {
                Icon = "popular.png"
            });

            page.Add(new MoviesPage(MovieTap.Toprated, pageService)
            {
                Icon = "topRated.png"
            });
        }
    }
}
