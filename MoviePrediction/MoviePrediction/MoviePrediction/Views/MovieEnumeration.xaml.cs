using MoviePrediction.Models;
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
	public partial class MovieEnumeration : ContentPage
	{
		public MovieEnumeration ()
		{
			InitializeComponent ();
		}

        public MovieEnumeration(IMovieIntro movie): this()
        {
        }
    }
}