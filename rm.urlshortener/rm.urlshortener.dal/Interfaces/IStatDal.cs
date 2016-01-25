// <copyright file="IStatDal.cs" company="Riccardo Merlin">
// Copyright (c) 2016 All Right Reserved
// </copyright>
// <author>Riccardo Merlin</author>
// <email>riccardomerlin@gmail.com</email>
// <date>2016-01-23</date>
// <summary>Stat Dal Interface</summary>
namespace rm.urlshortener.dal.Interfaces
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using rm.urlshortener.entity;

	/// <summary>
	/// IStatDal interface
	/// </summary>
	public interface IStatDal : ICommonDal<Stat>
	{
		/// <summary>
		/// Gets all hits by specific url id
		/// </summary>
		/// <param name="shortUrlCode">The url id</param>
		/// <returns>Return a list of hits</returns>
		IList<Stat> GetAll(string shortUrlCode);
	}
}
