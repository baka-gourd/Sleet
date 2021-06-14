namespace Sleet.Models {
    public class Suggestion {
        public string User { get; set; } //这个要上新类
        public string Content { get; set; }
        public bool Approved { get; set; }
        public string ApproveUser { get; set; } //这个也要上新类

        public void ApproveSuggestion() => Approved = true; //这里可以把接受人给整上
        public void RejectSuggestion() => Approved = false;
    }
}