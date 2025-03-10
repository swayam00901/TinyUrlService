namespace TinyUrl.Models
{
    public class UrlEntry
    {
        public string ShortCode { get; set; }
        public string LongUrl { get; set; }
        public int ClickCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
