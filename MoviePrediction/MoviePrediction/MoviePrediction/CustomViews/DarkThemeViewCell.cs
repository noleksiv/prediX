using Xamarin.Forms;

namespace MoviePrediction.CustomViews
{
    public class DarkThemeViewCell : ViewCell
    {
        public static readonly BindableProperty SelectedItemBackgroundColorProperty =
        BindableProperty.Create("SelectedItemBackgroundColor",
                                typeof(Color),
                                typeof(DarkThemeViewCell),
                                Color.Default);

        public Color SelectedItemBackgroundColor
        {
            get { return (Color)GetValue(SelectedItemBackgroundColorProperty); }
            set { SetValue(SelectedItemBackgroundColorProperty, value); }
        }
    }
}
