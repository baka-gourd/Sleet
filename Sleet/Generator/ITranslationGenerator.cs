using System.Collections.Generic;
using Sleet.Models;

namespace Sleet.Generator {
    public interface ITranslationGenerator {
        IEnumerable<Translation> Generate();
        public bool CanGenerate { get; set; }
    }
}