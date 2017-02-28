using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLive.Web.Models.SeoModels
{
    public class SitemapModel
    {
        public string loc { get; set; }
        public DateTime lastmod { get; set; }
    }

    public class SitemapUrlModel
    {
        //http://www.sitemaps.org/protocol.html
        //https://support.google.com/webmasters/answer/71453?hl=en&ref_topic=4581190
        public SitemapUrlModel()
        {
            changefreq = "always";
            lastmod = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            priority = 1.0f;
        }
        public string loc { get; set; }
        public DateTime lastmod { get; set; }

        /// <summary>
        /// always
        /// hourly
        /// daily
        /// weekly
        /// monthly
        /// yearly
        /// never
        /// </summary>
        public string changefreq { get; set; }
        public float priority { get; set; }

        //https://support.google.com/webmasters/answer/178636?hl=en&ref_topic=4581190
        public string image { get; set; }

        //https://support.google.com/webmasters/answer/80471?hl=en&ref_topic=4581190#creating
        #region Video Part
        public string v_content_loc { get; set; }
        public string v_player_loc { get; set; }
        public string v_thumbnail_loc { get; set; }
        public string v_title { get; set; }
        public string v_description { get; set; }

        /// <summary>
        /// Default Value: yes
        /// </summary>
        public bool v_player_alow_embeded { get; set; }

        /// <summary>
        /// Default Value: ap=1
        /// </summary>
        public bool v_autoplay { get; set; }
        #endregion
    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }
    }
}
