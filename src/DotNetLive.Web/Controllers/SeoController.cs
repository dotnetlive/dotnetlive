using DotNetLive.Web.Models.SeoModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetLive.Web.Controllers
{
    public class SeoController : MvcBaseController
    {
        // GET: /<controller>/
        public IActionResult RobotsPolicy()
        {
            StringBuilder sbRebots = new StringBuilder();
            sbRebots.AppendLine("User-Agent: *");
            sbRebots.AppendLine("Allow: /");
            sbRebots.AppendLine(string.Format("Sitemap: {0}/sitemap.xml", HostName));
            return Content(sbRebots.ToString(), "text/plain");
        }

        /// <summary>
        /// General Sitemap
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Sitemap()
        {
            Response.ContentType = "text/xml";
            var sitemapList = new List<SitemapModel>();
            sitemapList.Add(new SitemapModel() { loc = $"{HostName}/{"generalsitemap"}.xml", lastmod = DateTime.Now.Date });
            return View("SitemapIndex", sitemapList);
        }

        [HttpGet]
        public ActionResult GeneralSitemap()
        {
            Response.ContentType = "text/xml";

            var sitemapModel = new List<SitemapUrlModel>();
            sitemapModel.Add(new SitemapUrlModel() { loc = $"{HostName}{Url.RouteUrl("HomePage")}" });
            sitemapModel.Add(new SitemapUrlModel() { loc = $"{HostName}{Url.RouteUrl("Sitemap")}" });
            //sitemapModel.Add(new SitemapUrlModel() { loc = string.Format("{0}{1}", HostName, Url.RouteUrl("Links")) });
            //sitemapModel.Add(new SitemapUrlModel() { loc = string.Format("{0}{1}", HostName, Url.RouteUrl("TeamPolicy")) });
            //sitemapModel.Add(new SitemapUrlModel() { loc = string.Format("{0}{1}", HostName, Url.RouteUrl("PrivacePolicy")) });
            //sitemapModel.Add(new SitemapUrlModel() { loc = string.Format("{0}{1}", HostName, Url.RouteUrl("AboutUs")) });
            //sitemapModel.Add(new SitemapUrlModel() { loc = string.Format("{0}{1}", HostName, Url.RouteUrl("ContactUs")) });
            //sitemapModel.Add(new SitemapUrlModel() { loc = string.Format("{0}{1}", HostName, Url.RouteUrl("Help")) });
            return View("Sitemap", sitemapModel);
        }
    }
}
