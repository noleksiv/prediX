using MoviePrediction.Models;
using Rg.Plugins.Popup.Services;
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
        }

        private async void UsersIconClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsersPage());
        }

        private async void GoToMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void SearchIconClicked(object sender, EventArgs e)
        {
            try
            {
                await PopupNavigation.Instance.PushAsync(new Rg.Plugins.Popup.Pages.PopupPage());
                await Navigation.PushAsync(new HelpView("https://www.imdb.com/"));
            }
            catch (Exception)
            {

            }
            finally
            {
                await PopupNavigation.Instance.PopAsync();
            }
        }
    }
}