using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace griptide
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Graphics",
                url: "{controller}/{action}/{postID}",
                defaults: new { controller = "Graphics", action = "Index", postID = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "WebDesign",
                url: "{controller}/{action}/{postID}",
                defaults: new { controller = "WebDesign", action = "Index", postID = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "404-PageNotFound",
                url: "{error}/{Unknown}",
                defaults: new { controller = "Error", action = "Unknown" }
            );
            //routes.MapRoute(
            //    name: "GraphicsWithPost",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Graphics", action = "GetPost", postID = UrlParameter.Optional }
            //);
        }
    }
}