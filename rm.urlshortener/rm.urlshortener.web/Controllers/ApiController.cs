// <copyright file="UrlController.cs" company="Riccardo Merlin">
// Copyright (c) 2016 All Right Reserved
// </copyright>
// <author>Riccardo Merlin</author>
// <email>riccardomerlin@gmail.com</email>
// <date>2016-01-23</date>
// <summary>Url webapi controller</summary>
namespace rm.urlshortener.web.Controllers
{
	using dal.Interfaces;
	using dal;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http;
	using entity;
	using Code;

	/// <summary>
	/// 
	/// </summary>
	[RoutePrefix("urlshortener/api")]
	public class ApiController : BaseController, IApiController
	{
		/// <summary>
		/// Url service for Data Access
		/// </summary>
		private IUrlDal urlService;

		/// <summary>
		/// Stat service for Data Access
		/// </summary>
		private IStatDal statService;

		/// <summary>
		/// Initializes a new instance of the <see cref="ApiController"/> class
		/// </summary>
		public ApiController()
		{
			this.urlService = new UrlDal();
			this.statService = new StatDal();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="longUrl"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("urls")]
		public IHttpActionResult AddUrl([FromBody]Url url)
		{
			try
			{
				//TODO: url.LongUrl should be validates

				Url newUrl = new Url()
				{
					LongUrl = url.LongUrl,
					ShortUrl = Shortener.CreateShortUrlToken(),
					CreationDate = DateTime.Now
				};

				Url addedUrl = urlService.Add(newUrl);
				return this.Ok(addedUrl);
			}
			catch (Exception ex)
			{
				throw this.ThrowException(ex);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shortUrl"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("urls/{shortUrl}")]
		public IHttpActionResult GetUrl([FromUri] string shortUrl)
		{
			try
			{
				Url url = urlService.Get(shortUrl);
				return this.Ok(url);
			}
			catch (Exception ex)
			{
				throw this.ThrowException(ex);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("urls")]
		public IHttpActionResult GetAllUrls() //int pageIndex, int pageSize)
		{
			try
			{
				IList<Url> urls = urlService.GetAll();
				return this.Ok(urls);
			}
			catch (Exception ex)
			{
				throw this.ThrowException(ex);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shortUrlCode"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("urls/{shortUrlCode}/stats")]
		public IHttpActionResult GetUrlStatistics(string shortUrlCode)
		{
			try
			{
				IList<Stat> urlStatistics = statService.GetAll(shortUrlCode);
				var statList = from s in urlStatistics
							   group s by new { s.HitDate } into g
							   select new
							   {
								   Count = g.Count(),
								   Date = g.Key.HitDate,
							   };

				return this.Ok(new { stats = statList, totalCount = urlStatistics.Count });
			}
			catch (Exception ex)
			{
				throw this.ThrowException(ex);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="urlId"></param>
		/// <returns></returns>
		[HttpDelete]
		[Route("urls/{urlId:int:min(1)}")]
		public IHttpActionResult DeleteUrl(int urlId)
		{
			try
			{
				Url url = new entity.Url()
				{
					Id = urlId
				};

				Url deletedUrl = urlService.Delete(url);
				return this.Ok(deletedUrl);
			}
			catch (Exception ex)
			{
				throw this.ThrowException(ex);
			}
		}
	}
}
