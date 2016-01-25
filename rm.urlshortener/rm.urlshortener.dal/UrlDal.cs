// <copyright file="UrlDal.cs" company="Riccardo Merlin">
// Copyright (c) 2016 All Right Reserved
// </copyright>
// <author>Riccardo Merlin</author>
// <email>riccardomerlin@gmail.com</email>
// <date>2016-01-23</date>
// <summary>Url Dal class</summary>
namespace rm.urlshortener.dal
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using rm.urlshortener.dal.Interfaces;
	using rm.urlshortener.entity;

	/// <summary>
	/// 
	/// </summary>
	public class UrlDal : IUrlDal
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public Url Add(Url obj)
		{
			Url addedUrl = null;

			using (Entities model = new Entities())
			{
				addedUrl = model.Urls.Add(obj);
				model.SaveChanges();
			}

			return addedUrl;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public Url Delete(Url obj)
		{
			Url deletedUrl = null;

			using (Entities model = new Entities())
			{
				model.Urls.Attach(obj);
				model.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
				model.SaveChanges();
			}

			return deletedUrl;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shortUrl"></param>
		/// <returns></returns>
		public Url Get(string shortUrl)
		{
			Url url = null;

			using (Entities model = new Entities())
			{
				model.Configuration.ProxyCreationEnabled = false;
				url= model.Urls.FirstOrDefault(u=>u.ShortUrl == shortUrl);
			}

			return url;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Url Get(int id)
		{
			Url url = null;

			using (Entities model = new Entities())
			{
				model.Configuration.ProxyCreationEnabled = false;
				url = model.Urls.FirstOrDefault(u => u.Id == id);
			}

			return url;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IList<Url> GetAll()
		{
			IList<Url> urls = null;

			using (Entities model = new Entities())
			{
				model.Configuration.ProxyCreationEnabled = false;
				urls = model.Urls.OrderByDescending(u=>u.CreationDate).ToList();
			}

			return urls;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public Url Update(Url obj)
		{
			Url url = null;

			using (Entities model = new Entities())
			{
				url = model.Urls.Attach(obj);
				model.Entry(obj).State = System.Data.Entity.EntityState.Modified;
				model.SaveChanges();
			}

			return url;
		}
	}
}
