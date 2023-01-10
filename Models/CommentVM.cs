using BlogBlazorUI.components.Client;

namespace BlogBlazorUI.Models
{
    public class CommentVM
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string Name { get; set; } = null!;
        public string CommentContent { get; set; } = null!;
        public DateTime PublishDate { get; set; }

        public virtual ArticleVM Article { get; set; } = null!;
    }
}
