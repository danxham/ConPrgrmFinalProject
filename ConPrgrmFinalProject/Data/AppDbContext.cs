using ConPrgrmFinalProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConPrgrmFinalProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }

        public DbSet<FavoriteGame> FavoriteGames { get; set; }

        public DbSet<PetInfo> PetInfos { get; set; }


    }
}
