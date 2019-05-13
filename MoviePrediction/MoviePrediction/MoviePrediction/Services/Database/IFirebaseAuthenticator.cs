using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviePrediction.Services.Database
{
    public interface IFirebaseAuthenticator
    {
        /// <summary>
        /// Login with email and password.
        /// </summary>
        /// <returns>OAuth token</returns>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        Task<string> LoginWithEmailPassword(string email, string password);

        /// <summary>
        /// Registration with email and password.
        /// </summary>
        Task<string> RegsiterWithEmailPassword(string email, string password);
    }
}
