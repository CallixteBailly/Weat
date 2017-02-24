using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Weat.UI.Models.Transverse;

namespace Weat.UI.Controllers.Transverse
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BaseController : Controller 
    {
        protected WeatUser WeatUser = new WeatUser();

        protected override void Initialize(RequestContext requestContext)
        {
            if (!string.IsNullOrEmpty(requestContext.HttpContext.Request["culture"]))
            {
                Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new CultureInfo(requestContext.HttpContext.Request["culture"]);
            }

            base.Initialize(requestContext);

            // Grab the user's login information from Identity
            WeatUser weatUser = new WeatUser();
            if (User is ClaimsPrincipal)
            {
                var user = User as ClaimsPrincipal;
                var claims = user.Claims.ToList();

                var userStateString = GetClaim(claims, "UserState");

                if (!string.IsNullOrEmpty(userStateString))
                    weatUser = JsonConvert.DeserializeObject<WeatUser>(userStateString);
            }
            WeatUser = weatUser;

            ViewData["UserState"] = WeatUser;
        }
        public static string GetClaim(List<Claim> claims, string key)
        {
            var claim = claims.FirstOrDefault(c => c.Type == key);

            return claim?.Value;
        }
    }
}