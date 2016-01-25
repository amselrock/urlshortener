using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace rm.urlshortener.web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Stats",
				url: "s/{shorturl}/stats",
				defaults: new { controller = "Home", action = "Stats" }
			);

			routes.MapRoute(
				name: "Shortner",
				url: "s/{shorturl}",
				defaults: new { controller = "Home", action = "Redirect" }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}
