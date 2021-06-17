using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Sleet.Models;

namespace Sleet.Data
{
    /// <summary>
    /// Data in this class will be inject to the DbContext.
    /// </summary>
    public class InitialData
    {
        public List<Language> Languages = CultureInfo.GetCultures(CultureTypes.AllCultures)
            .Select(_ => new Language() {Id = new(), Code = _.Name, EnglishName = _.EnglishName}).ToList();
    }
}
