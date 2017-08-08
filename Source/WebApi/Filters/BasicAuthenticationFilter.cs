using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;

namespace WebApi.Filters
{
    public class BasicAuthenticationFilter : GenericAuthenticationFilter
    {
        /// <summary>
        /// BasicAuthenticationFilter constructor with isActive parameter
        /// </summary>
        /// <param name="isActive"></param>
        public BasicAuthenticationFilter(bool isActive)
            : base(isActive)
        {
        }

        /// <summary>
        /// Protected overriden method for authorizing user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        protected override bool OnAuthorizeUser(string username, string password, HttpActionContext actionContext)
        {
            var repo = new DataLib.Repository();
            if (repo.CheckAuthentication(username, password))
            {
                var basicAuthenticationIdentity = Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                    basicAuthenticationIdentity.ApplicationId = username;
                return true;                
            }
            return false;
        }
    }
}