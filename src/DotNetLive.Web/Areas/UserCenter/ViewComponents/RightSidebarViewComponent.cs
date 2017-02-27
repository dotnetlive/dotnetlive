using Microsoft.AspNetCore.Mvc;

namespace DotNetLive.Web.Areas.UserCenter.ViewComponents
{

    public class RightSidebarViewComponent : ViewComponent
    {
        public RightSidebarViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
