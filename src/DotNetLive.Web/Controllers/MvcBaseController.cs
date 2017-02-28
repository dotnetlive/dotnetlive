using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.Web.Controllers
{
    public class MvcBaseController : BaseController
    {
    }

    public class BaseController : Controller
    {
        public string HostName => $"{Request.Scheme}://{Request.Host.Value}";
    }
}
