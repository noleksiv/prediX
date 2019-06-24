using System;
using System.Threading.Tasks;
using Firebase.Auth;
using MoviePrediction.Helpers;
using MoviePrediction.Services.Database;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MoviePrediction.Droid.FirebaseAuthenticator))]
namespace MoviePrediction.Droid
{
    public class FirebaseAuthenticator : IFirebaseAuthenticator
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.
                        SignInWithEmailAndPasswordAsync(email, password);

            if (!user.User.IsEmailVerified)
                throw new Exception($"Email was sent to {user.User.Email} for varification");

            var token = await user.User.GetIdTokenAsync(false);
            var uid = user.User.Uid;

            Application.Current.Properties[ApplicationProperties.SessionId] = token.Token;
            Application.Current.Properties[ApplicationProperties.UserId] = uid;
            
            await Application.Current.SavePropertiesAsync();

            return token.Token;
        }

        public async Task<string> RegsiterWithEmailPassword(string email, string password)
        {
            var authResult = await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);

            using (var user = authResult.User)
            using (var actionCode = ActionCodeSettings.NewBuilder().SetAndroidPackageName(ApplicationProperties.ApplicationId, true, "0").Build())
            {
                await user.SendEmailVerificationAsync(actionCode);
            }

            var token = await authResult.User.GetIdTokenAsync(false);

            return token.Token;
        }
    }
}