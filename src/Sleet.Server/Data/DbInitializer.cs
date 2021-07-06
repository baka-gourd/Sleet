using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Sleet.Shared.Models;

namespace Sleet.Server.Data
{
    public class DbInitializer
    {
        public static List<Language> GenerateLanguages()
        {
            var languages = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Select(_ => new Language() { Id = Guid.NewGuid(), Code = _.Name, EnglishName = _.EnglishName,NativeName = _.NativeName}).ToList();
            return languages;
        }
    }
}
