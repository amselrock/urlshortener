// <copyright file="StatDal.cs" company="Riccardo Merlin">
// Copyright (c) 2016 All Right Reserved
// </copyright>
// <author>Riccardo Merlin</author>
// <email>riccardomerlin@gmail.com</email>
// <date>2016-01-23</date>
// <summary>Stat Dal class</summary>
namespace rm.urlshortener.dal
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Data.Entity;
	using System.Text;
	using System.Threading.Tasks;
	using rm.urlshortener.dal.Interfaces;
	using rm.urlshortener.entity;

	/// <summary>
	/// 
	/// </summary>
	public class StatDal : IStatDal
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public Stat Add(Stat obj)
		{
			Stat stat = null;
			using (Entities model = new Entities())
			{
				stat = model.Stats.Add(obj);
				model.SaveChanges();
			}

			return stat;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public Stat Delete(Stat obj)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Stat Get(int id)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IList<Stat> GetAll()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets all hits by specific url id
		/// </summary>
		/// <param name="shortUrlCode">The url id</param>
		/// <returns>Return a list of hits</returns>
		public IList<Stat> GetAll(string shortUrlCode)
		{
			List<Stat> hits = null;

			using (Entities model = new Entities())
			{
				model.Configuration.ProxyCreationEnabled = false;

				Url url = model.Urls.FirstOrDefault(u=>u.ShortUrl == shortUrlCode);
				if (url != null)
				{
					IQueryable<Stat> q = model.Stats.Where(s => s.UrlId == url.Id);
					hits = q.ToList();

					// reset time component
					hits.ForEach(s => s.HitDate = s.HitDate.Date);
                }
			}

			return hits;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public Stat Update(Stat obj)
		{
			throw new NotImplementedException();
		}
	}
}
