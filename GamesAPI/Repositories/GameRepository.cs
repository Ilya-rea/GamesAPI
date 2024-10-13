using System;
using GamesAPI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Repositories
{
	public class GameRepository : IRepository<GameForm>
	{
		private readonly AppDbContext _db;

		public GameRepository(AppDbContext db)
		{
			_db = db;
		}

		public IQueryable<GameForm> Get(string genre)
		{
			var gameList = _db.Games.Where(x =>x.Genre == genre);
			return gameList;
		}

        public IQueryable<GameForm> GetAll()
        {
            return _db.Games; 
        }

        public void Create(GameForm item)
		{
			_db.Games.Add(item);
            _db.SaveChanges();
        }

		public void Update(GameForm item)
		{
			bool gameContains = _db.Games.Any(x =>x.Id == item.Id);
			if (gameContains)
				_db.Entry(item).State = EntityState.Modified;
		}

		public void Delete(int id)
		{
			GameForm user = _db.Games.Find(id);
			if (user != null)
				_db.Games.Remove(user);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
		
	}
}

