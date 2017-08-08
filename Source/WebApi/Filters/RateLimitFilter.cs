using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Caching;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApi.Filters
{
    public class RateLimitFilter : ActionFilterAttribute
    {
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage =
            "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        private const string OwinContext = "MS_OwinContext";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var key = GetClientIp(actionContext.Request);

            if (HttpRuntime.Cache[key] == null)
            {
                HttpRuntime.Cache.Add(key,
                    new Attempts() { Number = 1 }, 
                    null, 
                    DateTime.Now.AddSeconds(60), 
                    Cache.NoSlidingExpiration,
                    CacheItemPriority.Low,
                    null); 
            }
            else
            {
                Attempts attempts = (Attempts)HttpRuntime.Cache[key];
                attempts.Number++;

                if (attempts.Number > 60)
                    HttpRuntime.Cache.Add("rateLimitExceeded",
                        (bool?)true, 
                        null, 
                        DateTime.Now.AddSeconds(300), // absolute expiration
                        Cache.NoSlidingExpiration,
                        CacheItemPriority.Low,
                        null); // no callback
            }

            var limitExceeded = (bool?)HttpRuntime.Cache["rateLimitExceeded"];
            if (limitExceeded.HasValue && limitExceeded.Value)
                actionContext.Response = actionContext.Request.CreateResponse(
                    HttpStatusCode.Forbidden
                );
        }

        private string GetClientIp(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey(HttpContext))
            {
                return ((HttpContextWrapper)request.Properties[HttpContext]).Request.UserHostAddress;
            }

            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                RemoteEndpointMessageProperty prop;
                prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessage];
                return prop.Address;
            }

            return null;
        }
    }

    class Attempts
    {
        public int Number { get; set; }
    }
}