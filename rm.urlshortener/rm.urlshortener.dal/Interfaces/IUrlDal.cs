// <copyright file="IUrlDal.cs" company="Riccardo Merlin">
// Copyright (c) 2016 All Right Reserved
// </copyright>
// <author>Riccardo Merlin</author>
// <email>riccardomerlin@gmail.com</email>
// <date>2016-01-23</date>
// <summary>Url Dal Interface</summary>
namespace rm.urlshortener.dal.Interfaces
{
	using rm.urlshortener.entity;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	/// <summary>
	/// 
	/// </summary>
	public interface IUrlDal: ICommonDal<Url>
	{
		/// <summary>
		///		
		/// </summary>
		/// <param name="shortUrl"></param>
		/// <returns></returns>
		Url Get(string shortUrl);
	}
}
