using DotNetLive.Framework.UserIdentity;
using DotNetLive.Framework.WebFramework.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace DotNetLive.Web.Controllers
{
    [Authorize]
    public class AccountController : BaseAccountController
    {
        public AccountController(IOptions<SecuritySettings> securitySetting) : base(securitySetting)
        {

        }
    }
}