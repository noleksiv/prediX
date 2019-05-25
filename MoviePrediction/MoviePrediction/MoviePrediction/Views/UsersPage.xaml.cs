using MoviePrediction.Convertors;
using MoviePrediction.Models;
using MoviePrediction.Services.Photo;
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
    public partial class UsersPage : ContentPage
    {
        public string UserIcon { get; set; } //= @"https://firebasestorage.googleapis.com/v0/b/pred1x.appspot.com/o/anon.jpg?alt=media&token=1783351c-3ad8-463a-b30f-c975692ead24";

        public ObservableCollection<HistoryPreview> History { get; set; }

        public UsersPage()
        {
            InitializeComponent();
            FillPage();
            this.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            FillPage();
        }

        private void FillPage()
        {
            var history = App.Database.GetItems();
            History = new ObservableCollection<HistoryPreview>(history);

            var imageUrl = new ImageUrl();

            foreach (var movie in History)
            {
                movie.PosterUrl = new Uri(imageUrl.CreatePosterLink(movie.PosterPath, ImageUrl.PosterSize.w185));
            }
        }

        private async void LogOutClicked(object sender, EventArgs e)
        {
            Application.Current.Properties.Remove("SessionId");
            Application.Current.Properties.Remove("Uid");

            await Application.Current.SavePropertiesAsync();
            
            await Navigation.PushAsync(new LoginPage());

            //Navigation.NavigationStack.ToList().Clear();

            StackNavigation.Clear(Navigation);
        }
    }
}