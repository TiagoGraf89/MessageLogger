using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApi.Filters
{
    /// <summary>
    /// Basic Authentication identity
    /// </summary>
    public class BasicAuthenticationIdentity : GenericIdentity
    {
        /// <summary>
        /// Get/Set for Secret
        /// </summary>
        public string Secret { get; set; }
        /// <summary>
        /// Get/Set for ApplicationId
        /// </summary>
        public string ApplicationId { get; set; }

        /// <summary>
        /// Basic Authentication Identity Constructor
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public BasicAuthenticationIdentity(string appId, string secret)
            : base(appId, "Basic")
        {
            Secret = secret;
            ApplicationId = appId;
        }
    }
}