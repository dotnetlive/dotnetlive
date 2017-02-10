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
            return Redirect($"{LoginUrl}/account/login?returnUrl={ GetEncodeReturlUrl(returnUrl)}");
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
            return Redirect($"{LoginUrl}/account/register?returnUrl={ GetEncodeReturlUrl(returnUrl)}");
        }

        [Authorize]
        public ActionResult LogOff(string returnUrl = "")
        {
            return Redirect($"{LoginUrl}/account/logoff?returnUrl={GetEncodeReturlUrl(returnUrl)}");
        }

        [Authorize]
        public ActionResult Manager()
        {
            return Redirect($"{LoginUrl}/manager");
        }

        #region Util
        public string LoginUrl => _securitySettings.LoginUrl.TrimEnd('/');
        #endregion
    }
}