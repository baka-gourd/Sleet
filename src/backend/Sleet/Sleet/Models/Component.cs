using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sleet.Models
{
    public class Component {
        
        public Guid Id { get; private set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public bool IsLock { get; set; }
        public List<Translation> Translations { get; set; }
    }
}
