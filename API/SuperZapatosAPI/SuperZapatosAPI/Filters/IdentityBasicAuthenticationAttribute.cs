using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SuperZapatosAPI.Filters
{
    public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
    {
        protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                //bool existLogin = UsersUtility.ExistLogin(userName);
                //mwLogin login = existLogin ? UsersUtility.GetLogin(userName, password) : null;

                if (userName.Equals("my_user") && password.Equals("my_password"))
                {
                    //_Globals.SetAppLoginId(login.loginId);

                    // Create a ClaimsIdentity with all the claims for this user.
                    Claim nameClaim = new Claim(ClaimTypes.Name, userName);
                    List<Claim> claims = new List<Claim> { nameClaim };

                    // important to set the identity this way, otherwise IsAuthenticated will be false
                    // see: http://leastprivilege.com/2012/09/24/claimsidentity-isauthenticated-and-authenticationtype-in-net-4-5/
                    ClaimsIdentity identity = new ClaimsIdentity(claims, "Basic");

                    var principal = new ClaimsPrincipal(identity);
                    return principal;
                }
            }
            catch (Exception ex)
            {
                //eventLogger.LogMsg(eventLogger.ErrorTypes.Error, Utility._Globals.logConfigName_MiddlewareError, ex, null, logToDB: false);
                //Intouch.Logger.Error("Middleware Access Error: ", ex);
                //abbLog.HandleBenefitsVerificationException(ex);
            }
            //if (userName != "testuser" || password != "Pass1word")
            //{
            // No user with userName/password exists.
            return null;
            //}


        }

    }
}