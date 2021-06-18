using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sleet.Models
{
    public class Component {
        public Component(Guid id, string name, List<Translation[]> translationsList, bool isLock = false, object description = null) {
            Id = id;
            Description = description;
            Name = name;
            IsLock = isLock;
            TranslationsList = translationsList;
        }

        public Guid Id { get; private set; }
        public Object Description { get; set; }
        public string Name { get; set; }
        public bool IsLock { get; set; }
        public List<Translation[]> TranslationsList { get; set; }
    }
    //public class Component
    //{
    //    public Guid Id { get; set; }
    //    public string Name { get; set; }
    //    public List<Translation> Translations { get; set; }
    //}
}
