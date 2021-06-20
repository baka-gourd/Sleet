using System;

namespace Sleet.Models
{
    public class Suggestion
    {
        public Guid Id { get; set; }
        public string User { get; set; } //这个要上新类
        public string Content { get; set; }
        public bool Approved { get; set; }
        public string ApproveUser { get; set; } //这个也要上新类
    }
}