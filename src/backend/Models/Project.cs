using System;
using System.Collections.Generic;

namespace Sleet.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public List<Component> Components { get; set; }
    }
}
