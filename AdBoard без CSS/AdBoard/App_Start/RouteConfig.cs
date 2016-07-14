using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdBoard
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AddAd",
                url: "addad",
                defaults: new { controller = "User", action = "AddAd" }
            );

            routes.MapRoute(
                name: "Registration",
                url: "registration",
                defaults: new { controller = "Registration", action = "Registration" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RemoveAd",
                url: "remove-ad/{id}",
                defaults: new { controller = "User", action = "RemoveAd", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "RemoveImage",
                url: "remove-image/{id}",
                defaults: new { controller = "User", action = "RemoveImage", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EditAd",
                url: "edit-ad/{id}",
                defaults: new { controller = "User", action = "EditAd", id = UrlParameter.Optional }
            );

        }
    }
}