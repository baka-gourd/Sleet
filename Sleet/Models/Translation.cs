using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Sleet.Models
{
    public class Translation
    {
        public Guid Id { get; set; }
        public string Key { get ; set ; }
        public bool IsOriginalLanguage { get; set; }
        public CultureInfo CultureInfo { get; set; }
        public string Content { get; set; }
        public List<Suggestion> Suggestions { get; set; }

    }
}
