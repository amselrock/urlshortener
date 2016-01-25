using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace rm.urlshortener.web.App_Start
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
					"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
					"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					"~/Scripts/bootstrap.js"));

			bundles.Add(new ScriptBundle("~/bundles/3rdparts").Include(
			  "~/Scripts/detectmobilebrowser.js",
			  "~/Scripts/chart.js"
			));

			bundles.Add(new ScriptBundle("~/bundles/angular").Include(
					"~/Scripts/angular.js",
					"~/Scripts/angular-sanitize.js",
					"~/Scripts/angular-messages.js",
					"~/Scripts/angular-touch.js",
					"~/Scripts/angular-block-ui.js",
					"~/Scripts/angular-chart.js"
			));

			bundles.Add(new ScriptBundle("~/bundles/app").Include(
					// modules
					"~/Scripts/app/app.module.js",
					"~/Scripts/app/app.module.config.js",
					// services
					"~/Scripts/app/app.factory.js",
					// directives
					"~/Scripts/app/url-shortener/url-shortener.directive.js",
					"~/Scripts/app/url-list/url-list.directive.js",
					"~/Scripts/app/url-statistics/url-statistics.directive.js"
			));

			bundles.Add(new StyleBundle("~/Content/css").Include(
				"~/Content/normalize.css",
				"~/Content/bootstrap.css",
				"~/Content/angular-block-ui.css",
				"~/Content/angular-chart.css",
				"~/Content/site.css"
			));
		}
	}
}