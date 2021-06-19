using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sleet.Models;

namespace Sleet.Data
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemory");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Language>().HasData(InitialData.Languages);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Translation> Translations { get; set;}
        
        public DbSet<Suggestion> Suggestions { get; set; }
        
        public DbSet<Component> Components { get; set; }
        
        public DbSet<Language> Languages { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}
