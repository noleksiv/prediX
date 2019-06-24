using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms.Extended;
using MoviePrediction.CustomViews;
using MoviePrediction.Models;
using MoviePrediction.Services.Popular;
using MoviePrediction.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public class CastPageViewModel : ViewModelBase
    {
        private bool _isBusy;
        private People _selectedActor;
        private const int _castsOnPage = 20;

        public IPageService _pageService;

        public People SelectedActor
        {
            get => _selectedActor;
            set
            {
                SetValue(ref _selectedActor, value, ActorSelectedCommand);
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                SetValue(ref _isBusy, value);
            }
        }

        public ICommand ActorSelectedCommand { get; private set; }

        public InfiniteScrollCollection<People> Cast { get; set; }

        public CastPageViewModel(IPageService pageService)
        {
            _pageService = pageService;
            ActorSelectedCommand = new Command<People>(async vm => await CustItemSelected(vm));

            Cast = new InfiniteScrollCollection<People>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;
                    await _pageService.PushAsync(new PopupLoading());
                    var cast = await LoadMorePeople();
                    await _pageService.PopAsync();
                    return cast;
                }
            };
            FillInPage();
        }

        public void FillInPage()
        {
            var cast = new PopularPeopleService();
            var people = cast.GetPeople();

            Cast.AddRange(people);
        }

        private async Task<IEnumerable<People>> LoadMorePeople()
        {
            var cast = new PopularPeopleService();
            var page = Cast.Count / _castsOnPage;
            var people = await cast.GetPeopleAsync(page + 1);

            return people;
        }

        private async Task CustItemSelected(People actor)
        {
            try
            {
                await _pageService.PushAsync(new PopupLoading());
                await _pageService.PushAsync(new CastDetails(actor));

            }
            catch (Exception ex)
            {                
            }
            finally
            {
                SelectedActor = null;
                await _pageService.PopAsync();
            }
        }
    }
}
