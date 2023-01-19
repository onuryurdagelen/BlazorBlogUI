using System.Xml.Linq;

namespace BlogBlazorUI.Models
{
    public class ArticleVM
    {
        public ArticleVM()
        {
            Comments = new HashSet<CommentVM>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ContentSummary { get; set; } = null!;
        public string ContentMain { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public string? Picture { get; set; }
        public int CategoryId { get; set; }
        public int ViewCount { get; set; }

        public virtual CategoryVM Category { get; set; } = null!;
        public virtual ICollection<CommentVM> Comments { get; set; }
    }
}
