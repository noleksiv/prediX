using MoviePrediction.CustomViews;
using MoviePrediction.Resources;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public class PageService : IPageService
    {
        public Page MainPage { get => Application.Current.MainPage; }
        public IPopupNavigation PopupPage { get => PopupNavigation.Instance; }

        public async Task<bool> DisplayAlert(string title, string message)
        {
            return await MainPage.DisplayAlert(title, message, AppResources.ConfirmText, AppResources.CancelText);
        }

        public async Task PushAsync(Page page)
        {
            await MainPage.Navigation.PushAsync(page);
        }

        public async Task PushAsync(PopupPage page)
        {
            await PopupPage.PushAsync(page);
        }

        public async Task PopAsync()
        {
            await PopupPage.PopAsync();
        }        
    }
}
