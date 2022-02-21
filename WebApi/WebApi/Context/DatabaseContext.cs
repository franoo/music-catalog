using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Context
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
           : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Albums).WithOne(a => a.User);
            modelBuilder.Entity<Album>().HasMany(a => a.Tracks).WithOne(t => t.Album);
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Track>().ToTable("Tracks");
            modelBuilder.Entity<Album>().ToTable("Albums");
        }
    }
}
