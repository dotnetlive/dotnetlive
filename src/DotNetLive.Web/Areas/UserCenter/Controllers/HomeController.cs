using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetLive.Web.Areas.UserCenter.Controllers
{
    [Area("usercenter")]
    //[Route("admin")]
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
            //return Content(DateTime.Now.ToString());
        }

        public IActionResult Dashboard_2()
        {
            return View();
        }

        public IActionResult Dashboard_3()
        {
            return View();
        }

        public IActionResult Dashboard_4_1()
        {
            return View();
        }

        public IActionResult Dashboard_5()
        {
            return View();
        }
    }
}
