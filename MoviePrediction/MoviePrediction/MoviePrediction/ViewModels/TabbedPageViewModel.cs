using MoviePrediction.Helpers;
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
                Icon = ImageNames.Latest,

            });

            page.Add(new MoviesPage(MovieTap.Upcoming, pageService)
            {
                Icon = ImageNames.Upcoming
            });

            page.Add(new MoviesPage(MovieTap.Popular, pageService)
            {
                Icon = ImageNames.Popular
            });

            page.Add(new MoviesPage(MovieTap.Toprated, pageService)
            {
                Icon = ImageNames.TopRated
            });
        }
    }
}
