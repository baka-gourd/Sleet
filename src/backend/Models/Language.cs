using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sleet.Models
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string EnglishName { get; set; }
    }
}
