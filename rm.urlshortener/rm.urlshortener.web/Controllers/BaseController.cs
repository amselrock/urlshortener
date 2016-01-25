// <copyright file="BaseController.cs" company="Riccardo Merlin">
// Copyright (c) 2016 All Right Reserved
// </copyright>
// <author>Riccardo Merlin</author>
// <email>riccardomerlin@gmail.com</email>
// <date>2016-01-23</date>
// <summary>Base Controller for web api controllers</summary>
namespace rm.urlshortener.web.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http;

	/// <summary>
	/// Base controller class
	/// </summary>
	public class BaseController : System.Web.Http.ApiController
    {
		/// <summary>
		/// log4net instance
		/// </summary>
		private readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		/// <summary>
		/// Exception handler to log and throw custom exceptions
		/// </summary>
		/// <param name="ex">The original exception</param>
		/// <param name="errorMessage">custom error message</param>
		/// <param name="statusCode">Http status code</param>
		/// <returns>Returns a Http exception</returns>
		protected HttpResponseException ThrowException(Exception ex, string errorMessage = "", HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
		{
			if (string.IsNullOrWhiteSpace(errorMessage))
			{
				errorMessage = "An error is occurred";
			}

			this.logger.Error(errorMessage, ex);
			return new HttpResponseException(Request.CreateErrorResponse(statusCode, new HttpError(new Exception(errorMessage), true)));
		}

	}
}
