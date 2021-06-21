using System;

namespace Sleet.Models
{
    public class Suggestion
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public bool Approved { get; set; }
        public User Approver { get; set; }
    }
}