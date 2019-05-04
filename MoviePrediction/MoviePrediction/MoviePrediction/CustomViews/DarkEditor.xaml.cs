using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviePrediction.CustomViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DarkEditor : ContentView
	{
        public static Color White { get; set; } = Color.FromHex("#F8F8F8");

        public DarkEditor ()
		{
            InitializeComponent();

            EntryField.BindingContext = this;
            EntryField.Focused += async (s, a) =>
            {
                HiddenBottomBorder.BackgroundColor = AccentColor;
                EntryField.TextColor = HiddenLabel.TextColor = AccentColor;
                HiddenLabel.IsVisible = true;
                if (string.IsNullOrEmpty(EntryField.Text))
                {
                    //Here we give animation on label position, label fading and box view.  
                    await Task.WhenAll(HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, BottomBorder.Width, BottomBorder.Height + 2), 200), HiddenLabel.FadeTo(1, 100), HiddenLabel.TranslateTo(HiddenLabel.TranslationX - 25, EntryField.Y - EntryField.Height, 200, Easing.BounceIn));
                    EntryField.Placeholder = null;
                }
                else
                {
                    await HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, BottomBorder.Width, BottomBorder.Height), 200);
                }
            };
            EntryField.Unfocused += async (s, a) =>
            {
                if (string.IsNullOrEmpty(EntryField.Text))
                {
                    await Task.WhenAll(HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, 0, BottomBorder.Height + 2), 200), HiddenLabel.FadeTo(0, 120), HiddenLabel.TranslateTo(HiddenLabel.TranslationX + 25, EntryField.Y, 50, Easing.BounceIn));
                    EntryField.Placeholder = Placeholder;
                }
                else
                {
                    await HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, 0, BottomBorder.Height), 100);
                }
            };
        }
        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(DarkEditor), defaultBindingMode: BindingMode.TwoWay);
        public static BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(DarkEditor), defaultBindingMode: BindingMode.TwoWay, propertyChanged: (bindable, oldVal, newval) => {
            var matEntry = (DarkEditor)bindable;
            matEntry.EntryField.Placeholder = (string)newval;
            matEntry.EntryField.PlaceholderColor = White;
            matEntry.HiddenLabel.Text = (string)newval;
        });
        public static BindableProperty IsPasswordProperty = BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(DarkEditor), defaultValue: false, propertyChanged: (bindable, oldVal, newVal) => {
            var matEntry = (DarkEditor)bindable;
            matEntry.EntryField.IsPassword = (bool)newVal;
        });
        public static BindableProperty KeyboardProperty = BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(DarkEditor), defaultValue: Keyboard.Default, propertyChanged: (bindable, oldVal, newVal) => {
            var matEntry = (DarkEditor)bindable;
            matEntry.EntryField.Keyboard = (Keyboard)newVal;
        });
        public static BindableProperty AccentColorProperty = BindableProperty.Create(nameof(AccentColor), typeof(Color), typeof(DarkEditor), defaultValue: Color.Accent);
        public Color AccentColor
        {
            get => (Color)GetValue(AccentColorProperty);
            set => SetValue(AccentColorProperty, value);
        }
        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }
        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }
        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }
    }
}