// <copyright file="IApiController.cs" company="Riccardo Merlin">
// Copyright (c) 2016 All Right Reserved
// </copyright>
// <author>Riccardo Merlin</author>
// <email>riccardomerlin@gmail.com</email>
// <date>2016-01-23</date>
// <summary>Interface for Api Controller</summary>
namespace rm.urlshortener.web.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using rm.urlshortener.entity;
	using System.Web.Http;

	/// <summary>
	/// IApiController Interfcace
	/// </summary>
	public interface IApiController
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="newUrl"></param>
		/// <returns></returns>
		IHttpActionResult AddUrl(Url url);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shortUrl"></param>
		/// <returns></returns>
		IHttpActionResult GetUrl(string shortUrl);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pageIndex"></param>
		/// <param name="pageSize"></param>
		/// <returns></returns>
		IHttpActionResult GetAllUrls(); //int pageIndex, int pageSize);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shortUrlCode"></param>
		/// <returns></returns>
		IHttpActionResult GetUrlStatistics(string shortUrlCode);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="urlId"></param>
		/// <returns></returns>
		IHttpActionResult DeleteUrl(int urlId);
	}
}
