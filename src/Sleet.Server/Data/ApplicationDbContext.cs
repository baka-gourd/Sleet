using Microsoft.EntityFrameworkCore;
using Sleet.Shared.Models;

namespace Sleet.Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(DbInitializer.GenerateLanguages());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Translation> Translations { get; set;}
        
        public DbSet<Suggestion> Suggestions { get; set; }
        
        public DbSet<Component> Components { get; set; }
        
        public DbSet<Language> Languages { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}
