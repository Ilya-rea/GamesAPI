using System;
using GamesAPI.Repositories;
using GamesAPI.Models;
using System.Linq;

namespace GamesAPI.Services
{
	public class ModelMapping : IModelMapping
	{
		private readonly IRepository<GameForm> _gameRepository;

		public ModelMapping(IRepository<GameForm> gameRepository)
		{
			_gameRepository = gameRepository;
		}

		public IQueryable<GameForm> Get(string genre)
		{
			return _gameRepository.Get(genre);
		}

        public IQueryable<GameForm> GetAll()
        {
            return _gameRepository.GetAll();
        }

        public void Create(GameForm gameForm)
		{
				_gameRepository.Create(gameForm);
				_gameRepository.Save();
		}

		public void Update(GameForm gameForm)
		{
                _gameRepository.Update(gameForm);
                _gameRepository.Save(); 
        }

		public void Delete(int id)
		{
			_gameRepository.Delete(id);
			_gameRepository.Save();
		}
	
	}
}

