using System;
using GamesAPI.Models;

namespace GamesAPI.Services
{
	public interface IModelMapping
	{
		IQueryable<GameForm> Get(string genre);
        IQueryable<GameForm> GetAll();
        void Create(GameForm gameForm);
		void Update(GameForm gameForm);
		void Delete(int id);
	}
}

