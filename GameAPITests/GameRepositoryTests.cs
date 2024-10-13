using GamesAPI.Models;
using GamesAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace GamesAPITests
{
    public class GameRepositoryTests : IDisposable
    {
        private readonly AppDbContext _dbContext;
        private readonly GameRepository _repository;

        public GameRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _dbContext = new AppDbContext(options);
            _repository = new GameRepository(_dbContext);
        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [Fact]
        public void Get_GamesByGenre()
        {
            var genre1Game = new GameForm { nameOfGame = "Game 1", studio = "Studio A", Genre = "Genre 1" };
            var genre2Game = new GameForm { nameOfGame = "Game 2", studio = "Studio B", Genre = "Genre 2" };

            _dbContext.Games.Add(genre1Game);
            _dbContext.Games.Add(genre2Game);
            _dbContext.SaveChanges();

            var result = _repository.Get("Genre 1").ToList();

            Assert.Single(result);
            Assert.Equal("Game 1", result[0].nameOfGame);
            Assert.Equal("Studio A", result[0].studio);
        }

        [Fact]
        public void Update_ChangesGame()
        {
            var game = new GameForm { nameOfGame = "Old Game", studio = "Old Studio", Genre = "Old Genre" };
            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            game.nameOfGame = "Updated Game";
            game.studio = "Updated Studio";
            _repository.Update(game);
            _repository.Save();

            var updatedGame = _dbContext.Games.FirstOrDefault(g => g.Id == game.Id);
            Assert.NotNull(updatedGame);
            Assert.Equal("Updated Game", updatedGame.nameOfGame);
        }

        [Fact]
        public void Delete_Game()
        {
            var game = new GameForm { nameOfGame = "Game to Delete", studio = "Studio", Genre = "Genre" };
            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            _repository.Delete(game.Id);
            _repository.Save();

            var deletedGame = _dbContext.Games.FirstOrDefault(g => g.Id == game.Id);
            Assert.Null(deletedGame);
        }
    }
}

