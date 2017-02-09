using DotNetLive.Framework.UserIdentity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net;

namespace DotNetLive.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private SecuritySettings _securitySettings;

        public AccountController(IOptions<SecuritySettings> securitySetting)
        {
            this._securitySettings = securitySetting.Value;
        }

        [AllowAnonymous]
        public ActionResult Login(string userNameOrEmailAddress = "", string returnUrl = "", string successMessage = "")
        {
            return Redirect($"{_securitySettings.LoginUrl}/account/login?returnUrl={ GetEncodeReturlUrl(returnUrl)}");
        }

        private string GetEncodeReturlUrl(string returnUrl)
        {
            var context = Request.HttpContext;
            //@($"{Context.Request.Scheme}://{Context.Request.Host}{Context.Request.Path}{Context.Request.QueryString}")
            return WebUtility.UrlEncode($"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}");
        }

        [AllowAnonymous]
        public ActionResult Register(string returnUrl)
        {
            return Redirect($"{_securitySettings.LoginUrl}?returnUrl={ GetEncodeReturlUrl(returnUrl)}");
        }

        [Authorize]
        public ActionResult LogOff(string returnUrl = "")
        {
            //AuthorizationService.Instance.ClearAuthorizationCache(ApplicationUser.UserId);//ÒÆ³ýUser Permission Cache
            //var authenticationManger = HttpContext.GetOwinContext().Authentication;
            //authenticationManger.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            //authenticationManger.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect($"{_securitySettings.LoginUrl}/account/logoff?returnUrl={GetEncodeReturlUrl(returnUrl)}");
        }
    }
}