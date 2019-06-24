using Firebase.Database;
using Firebase.Database.Query;
using MoviePrediction.Helpers;
using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviePrediction.Services.Database
{
    public class DbFirebase
    {
        private const string _tabName = "watchlist";

        public async Task<string> SignUp(string email, string pwd)
        {
            var token = await DependencyService.Get<IFirebaseAuthenticator>()
                                               .RegsiterWithEmailPassword(email, pwd);
            return token;
        }

        public async Task<string> SignIn(string email, string pwd)
        {
            var token = await DependencyService.Get<IFirebaseAuthenticator>()
                                               .LoginWithEmailPassword(email, pwd);
            return token;
        }

        public async Task AddToHistory(IMovieIntro movie)
        {
            var firebase = new FirebaseClient(LinksContainer.PredixFirebase);
            var uniqueUserToken = Application.Current.Properties[ApplicationProperties.UserId].ToString();

            // add an id to the watchlist
            await firebase.Child(uniqueUserToken).Child(_tabName)
                                                 .Child(movie.Id.ToString())
                                                 .PutAsync(JsonConvert.SerializeObject(movie));
        }

        public async Task<IObservable<MovieShort>> GetAllMovies(MovieShort movie)
        {
            var firebase = new FirebaseClient(LinksContainer.PredixFirebase);
            var uniqueUserToken = Application.Current.Properties[ApplicationProperties.UserId].ToString();

            return await Task.Run(() =>
            {
                var history = firebase.Child(uniqueUserToken).AsObservable<MovieShort>();
                return (IObservable<MovieShort>)history;
            });
        }
    }
}
