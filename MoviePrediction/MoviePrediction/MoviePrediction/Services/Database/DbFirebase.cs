using Firebase.Database;
using Firebase.Database.Query;
using MoviePrediction.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MoviePrediction.Services.Database
{
    public class DbFirebase
    {
        public string DatabaseUrl { get; set; } = @"https://pred1x.firebaseio.com/";

        public async Task<string> SignUp(string email, string pwd)
        {
            var token = await DependencyService.Get<IFirebaseAuthenticator>().RegsiterWithEmailPassword(email, pwd);
            return token;            
        }

        public async Task<string> SignIn(string email, string pwd)
        {
            var token = await DependencyService.Get<IFirebaseAuthenticator>().LoginWithEmailPassword(email, pwd);
            return token;
        }

        public async Task AddToHistory(IMovieIntro movie)
        {
            var firebase = new FirebaseClient(DatabaseUrl);
            var uniqueUserToken = Xamarin.Forms.Application.Current.Properties["Uid"].ToString();

            // add an id to the watchlist
            await firebase.Child(uniqueUserToken).Child("watchlist").Child(movie.Id.ToString())
                  .PutAsync(JsonConvert.SerializeObject(movie));
        }

        public async Task<IObservable<MovieShort>> GetAllMovies(MovieShort movie)
        {
            var firebase = new FirebaseClient(DatabaseUrl);
            var uniqueUserToken = Xamarin.Forms.Application.Current.Properties["Uid"].ToString();            

            return await Task.Run(() => {
                var history = firebase.Child(uniqueUserToken).AsObservable<MovieShort>();
                return (IObservable<MovieShort>)history;
            });
        }
    }
}
