using System;
using System.Collections.Generic;

namespace Sleet.Models
{
    public class Component {
        
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsLock { get; set; }
        public List<Translation> Translations { get; set; }
    }
}
