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
	public partial class HelpView : ContentPage
	{
        public string RedirectUrl { get; set; }

        public HelpView ()
		{
			InitializeComponent ();
            RedirectUrl = "https://help.netflix.com/en/";
            this.BindingContext = this;
        }

        public HelpView(string url)
        {
            InitializeComponent();
            RedirectUrl = url;
            this.BindingContext = this;
        }

        private async void GoToMainPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}