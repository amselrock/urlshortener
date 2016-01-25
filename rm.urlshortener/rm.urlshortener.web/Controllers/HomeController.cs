using rm.urlshortener.dal;
using rm.urlshortener.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace rm.urlshortener.web.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Redirect()
		{
			string shortUrl = ControllerContext.RouteData.Values["shorturl"].ToString();
			UrlDal urlDal = new UrlDal();
			Url url = urlDal.Get(shortUrl);
			if (url != null)
			{
				// add url hit
				StatDal statDal = new StatDal();
				statDal.Add(new Stat()
				{
					HitDate = DateTime.Now,
					UrlId = url.Id
				});

				return new RedirectResult(url.LongUrl);
			}

			return new RedirectToRouteResult(new RouteValueDictionary(new
			{
				action = "NotFound",
				controller = "Home"
			}));
		}

		public ActionResult Stats()
		{
			return View();
		}

		public ActionResult NotFound()
		{
			return View();
		}
	}
}