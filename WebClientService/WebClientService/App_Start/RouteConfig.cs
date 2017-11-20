using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebClientService.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // routes.MapRoute(
            //    name: "Search",
            //    url: "tra-cuu-thong-tin/{id}",
            //    defaults: new { controller = "Search", action = "Index", id = UrlParameter.Optional },
            //    namespaces: new string[] { "NCKH_Website.Controllers" }

            //);

           // routes.MapRoute(
           //    name: "Search",
           //    url: "tra-cuu-thong-tin/{id}",
           //    defaults: new { controller = "Search", action = "Index", id = UrlParameter.Optional },
           //    namespaces: new string[] { "NCKH_Website.Controllers" }

           //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TraCuu", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebClientService.Controllers" }

            );
        }
    }
}
