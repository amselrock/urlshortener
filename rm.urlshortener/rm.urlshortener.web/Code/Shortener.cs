using rm.urlshortener.dal;
using rm.urlshortener.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace rm.urlshortener.web.Code
{
	public class Shortener
	{
		const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

		public static string CreateShortUrlToken()
		{
			var random = new Random();
			string shortUrl = new string(Enumerable.Repeat(chars, 5).Select(s => s[random.Next(s.Length)]).ToArray());

			// check uniqueness of token
			UrlDal dal = new UrlDal();
			Url url = dal.Get(shortUrl);

			while (url != null)
			{
				shortUrl = CreateShortUrlToken();
			}

			return shortUrl;
		}
	}
}