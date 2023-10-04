using System.ComponentModel.DataAnnotations.Schema;

namespace InforceAPI.Models
{
    public class Url
    {
        public int UrlId { get; set; }
        public string Date { get; set; } = string.Empty;
        public string LongUrl { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;

        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
