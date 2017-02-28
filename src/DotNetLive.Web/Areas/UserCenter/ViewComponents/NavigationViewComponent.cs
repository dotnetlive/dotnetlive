using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.Web.Areas.UserCenter.ViewComponents
{
    public class NavigationViewComponent : ViewComponent
    {
        public NavigationViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
