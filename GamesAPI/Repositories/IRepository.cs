using System;
using GamesAPI.Models;
using System.Collections.Generic;
namespace GamesAPI.Repositories
{
	public interface IRepository<T> where T : class
	{
		IQueryable<T> Get(string genre);
        IQueryable<T> GetAll();
        void Create(T item);
		void Update(T item);
		void Delete(int id);
		void Save();
	}
}

