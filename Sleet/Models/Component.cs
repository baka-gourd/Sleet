using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sleet.Models
{
    public class Component {
        public Guid Id { get; set; }
        public Object Description { get; set; }
        public string Name { get; set; }
        public List<Translation[]> TranslationsList { get; set; }
    }
    //public class Component
    //{
    //    public Guid Id { get; set; }
    //    public string Name { get; set; }
    //    public List<Translation> Translations { get; set; }
    //}
}
