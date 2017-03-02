﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DotNetLive.Framework.DependencyManagement;

namespace DotNetLive.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var env = services.BuildServiceProvider().GetService<IHostingEnvironment>();
            services.AddSingleton<IServiceCollection>(factory => services);
            //services.AddSingleton<IContainer>(factory => ApplicationContainer);
            services.AddSingleton<IConfigurationRoot>(factory => Configuration);
            services.AddTrace();

            //先通过asp.net core ioc注册
            services.AddDependencyRegister(Configuration);
            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseClaimsTransformation();
            app.UseTraceCapture();
            app.UseTracePage();

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areaRoute", template: "{area:exists}/{controller=Home}/{action=Index}");
                #region Sitemap 站点地图部分
                routes.MapRoute(name: "RebotsPolicy", template: "robots.txt", defaults: new { controller = "Seo", action = "RobotsPolicy" });
                routes.MapRoute(name: "GeneralSitemap", template: "generalsitemap.xml", defaults: new { controller = "Seo", action = "GeneralSitemap" });
                routes.MapRoute(name: "SitemapIndex", template: "sitemap.xml", defaults: new { controller = "Seo", action = "Sitemap" });
                #endregion

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
