using Firebase.Database;
using System.Threading.Tasks;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MoviePrediction.Services.Database
{
    public class DbFirebase
    {
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
    }
}
