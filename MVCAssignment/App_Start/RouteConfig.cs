//App_Start/RouteConfig.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCAssignment
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //GuessingGame
            routes.MapRoute(
            name: "GuessingGame",
            url: "GuessingGame",
            defaults: new { controller = "Features", action = "GuessingGame" });

            //FeverCheck
            routes.MapRoute(
                name: "FeverCheck",
                url: "FeverCheck",
                defaults: new { controller = "Features", action = "FeverCheck" });

            //Home/Index
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

        }
    }
}
