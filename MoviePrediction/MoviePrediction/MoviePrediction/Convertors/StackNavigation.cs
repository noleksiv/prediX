using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviePrediction.Convertors
{
    public static class StackNavigation
    {
        public static void Clear(INavigation navigation)
        {
            var navigationStack = navigation.NavigationStack;

            Parallel.ForEach(navigationStack, page => navigation.RemovePage(page));
        }
    }
}
