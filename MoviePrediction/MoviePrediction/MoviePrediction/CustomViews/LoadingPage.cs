using MoviePrediction.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MoviePrediction.CustomViews
{
    public class LoadingPage : ContentPage
    {
        Image splashImage;

        public LoadingPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "predix.png",
                WidthRequest = 300,
                HeightRequest = 90
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#000000");
            this.Content = sub;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 5000); //Time-consuming processes such as initializatio

            try
            {
                if (Application.Current.Properties.ContainsKey("SessionId"))
                {
                    Application.Current.MainPage = new NavigationPage(new MainPage());
                }
                else
                {
                    Application.Current.MainPage = new NavigationPage(new LoginPage());
                }
            }
            finally
            {
                await splashImage.ScaleTo(0.9, 1500, Easing.Linear);
                await splashImage.ScaleTo(150, 1200, Easing.Linear);
            }
        }
    }
}
