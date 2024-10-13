using System;
using Microsoft.EntityFrameworkCore;

namespace GamesAPI.Models
{

        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<GameForm> Games { get; set; }
        }
}

