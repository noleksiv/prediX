using MoviePrediction.Models;
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

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<IMovieIntro, HistoryPreview>().ForMember(preview => preview.TheMovieDbId, movie => movie.MapFrom(intro => intro.Id))
                                                            .ForMember(preview=>preview.Id, movie=>movie.Ignore());
            });
        }

        private async void UsersIconClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsersPage());
        }
    }
}