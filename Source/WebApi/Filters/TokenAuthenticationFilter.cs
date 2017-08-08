using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi.Filters
{
    public class TokenAuthenticationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            var repo = new DataLib.Repository();
            var authToken = this.FetchAuthHeader(filterContext);
            if (authToken == null)
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            else if (!repo.CheckTokenAuthentication(authToken))
            {
                var responseMessage = new HttpResponseMessage(HttpStatusCode.Forbidden)
                {
                    ReasonPhrase = "Invalid Request"
                };
                filterContext.Response = responseMessage;
            }
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Checks for autrhorization header in the request and parses it, creates user credentials and returns as BasicAuthenticationIdentity
        /// </summary>
        /// <param name="filterContext"></param>
        protected string FetchAuthHeader(HttpActionContext filterContext)
        {
            string authHeaderValue = null;
            var authRequest = filterContext.Request.Headers.Authorization;
            if (authRequest != null && !String.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Bearer")
                authHeaderValue = authRequest.Parameter;
            if (string.IsNullOrEmpty(authHeaderValue))
                return null;
            try
            {
                authHeaderValue = Encoding.Default.GetString(Convert.FromBase64String(authHeaderValue));
            } catch
            {
                // Do nothing
            }
            return authHeaderValue;
        }

    }
}