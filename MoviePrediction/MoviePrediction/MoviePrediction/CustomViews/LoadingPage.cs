using MoviePrediction.Helpers;
using MoviePrediction.Views;
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
                Source = ImageNames.Predix,
                WidthRequest = 300,
                HeightRequest = 90
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.Black;
            this.Content = sub;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 5000); 

            try
            {
                if (Application.Current.Properties.ContainsKey(ApplicationProperties.SessionId))
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
