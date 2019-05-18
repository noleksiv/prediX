using MoviePrediction.Models;
using MoviePrediction.Services.Photo;
using MoviePrediction.Services.Popular;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Extended;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CastPage : ContentPage
	{
        private bool _isBusy;
        private int _peopleOnPage;
        private ImageUrl imageUrl = new ImageUrl();
        

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public InfiniteScrollCollection<People> Cast { get; set; }

        public CastPage ()
		{
            InitializeComponent();
            Cast = new InfiniteScrollCollection<People> { OnLoadMore = async () => 
            {
                IsBusy = true;

                await LoadMorePeople();

                // Itens que serão adicionados
                return Cast;
            } };
            FillInPage();
            this.BindingContext = this;
        }

        public void FillInPage()
        {
            var cast = new GetPopularPeople();
            var people = cast.GetPeople();

            Cast.AddRange(people);

            foreach (var human in Cast)
            {
                human.ProfileUrl = new Uri(imageUrl.CreatePosterLink(human.ProfilePath));
            }

            _peopleOnPage = Cast.Count;
        }

        private async Task LoadMorePeople()
        {
            var cast = new GetPopularPeople();
            var page = Cast.Count / _peopleOnPage;
            var people = await cast.GetPeopleAsync(page+1);

            foreach (var human in people)
            {
                human.ProfileUrl = new Uri(imageUrl.CreatePosterLink(human.ProfilePath));
            }

            Cast.AddRange(people);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void CustItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            var selectedItem = ((ListView)sender).SelectedItem;
            var movie = selectedItem as People;

            // connection to Firebase
            //var db = new DbFirebase();
            //await db.AddToHistory(movie);

            await Navigation.PushAsync(new CastDetails(movie));

            populatCastListView.SelectedItem = null;
        }
    }
}