using System;

namespace Sleet.Models
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string EnglishName { get; set; }
        public string NativeName { get; set; }

    }
}
