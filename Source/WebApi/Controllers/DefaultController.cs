using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [RateLimitFilter()]
    [RoutePrefix("api/default")]
    public class DefaultController : ApiController
    {
        [BasicAuthenticationFilter(true)]
        [Route("auth")]
        [HttpPost]
        public Models.AuthResponse Auth()
        {
            if (System.Threading.Thread.CurrentPrincipal != null 
                && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
            {
                var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                if (basicAuthenticationIdentity != null)
                {
                    var repo = new DataLib.Repository();
                    var appId = basicAuthenticationIdentity.ApplicationId;
                    var token = repo.GenerateToken(appId);
                    return new Models.AuthResponse()
                    {
                        Access_Token = token.Token
                    };
                }
            }
            return null;           
        }

        [Route("register")]
        [AllowAnonymous]
        [ModelValidationFilterAttribute]
        [HttpPost]
        public DataLib.Models.ApplicationModel Register([FromBody] Models.RegisterRequest request)
        {
            var repo = new DataLib.Repository();
            var app = new DataLib.Models.ApplicationModel()
            {
                Display_Name = request.Display_Name,
                Application_Id = Guid.NewGuid().ToString().Replace("-", ""),
            };
            app.Secret = app.Application_Id.Substring(0, 25);
            repo.InsertApplication(app);

            return app;
        }

        [Route("log")]
        [ModelValidationFilterAttribute]
        [TokenAuthenticationFilter]
        [HttpPost]
        public Models.SaveResponse Log([FromBody] Models.MessageLogModel request)
        {
            var repo = new DataLib.Repository();
            var app = repo.GetApplication(request.Application_Id);
            if (app == null)
                return new Models.SaveResponse() { Success = false };

            var log = new DataLib.Models.MessageModel()
            {
                Logger = request.Logger,
                Level = request.Level,
                Application_Id = request.Application_Id,
                Message = request.Message
            };
            repo.InsertMessageLog(log);
            return new Models.SaveResponse() { Success = true };
        }

    }
}
