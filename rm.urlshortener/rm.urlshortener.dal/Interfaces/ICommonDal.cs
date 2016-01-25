// <copyright file="ICommonDal.cs" company="Riccardo Merlin">
// Copyright (c) 2016 All Right Reserved
// </copyright>
// <author>Riccardo Merlin</author>
// <email>riccardomerlin@gmail.com</email>
// <date>2016-01-23</date>
// <summary>Generic Dal Interface</summary>
namespace rm.urlshortener.dal.Interfaces
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ICommonDal<T>
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		T Add(T obj);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		T Get(int id);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		IList<T> GetAll();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		T Delete(T obj);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		T Update(T obj);
	}
}
