using BusinessLogicLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ApplicationLayer.Auth
{
    public class ELogged : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext) 
        {
            var token = actionContext.Request.Headers.Authorization;
            if (token == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { message = "No token supplied" });
            }
            else if (!AuthService.IsTokenValid(token.ToString()))
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { message = "Invalid or Expired Token" });
            }

            base.OnAuthorization(actionContext);
        }
    }
}