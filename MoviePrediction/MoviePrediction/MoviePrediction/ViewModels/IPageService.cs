using MoviePrediction.CustomViews;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviePrediction.ViewModels
{
    public interface IPageService
    {
        Task PushAsync(Page page);
        Task PushAsync(PopupPage page);
        Task PopAsync();
        Task<bool> DisplayAlert(string title, string message);
    }
}
