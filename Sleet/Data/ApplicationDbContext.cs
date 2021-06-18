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
            modelBuilder.Entity<Translation>().HasData(Translations); //不知道怎么整先不报错再说
            base.OnModelCreating(modelBuilder);
        }

        [Column("translations")]
        public DbSet<Translation> Translations { get; set;}
        [Column("suggestions")]
        public DbSet<Suggestion> Suggestions { get; set; }
        [Column("components")]
        public DbSet<Component> Components { get; set; }
        [Column("languages")]
        public DbSet<Language> Languages { get; set; }
    }
}
