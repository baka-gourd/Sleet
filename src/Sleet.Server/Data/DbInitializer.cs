using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Sleet.Shared.Models;

namespace Sleet.Server.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Languages.Any())
            {
                return;
            }
            var languages = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Select(_ => new Language() { Id = Guid.NewGuid(), Code = _.Name, EnglishName = _.EnglishName }).ToList();
            context.Languages.AddRange(languages);
            context.SaveChanges();
        }
    }
}
