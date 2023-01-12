using BlogBlazorUI.components.Client;

namespace BlogBlazorUI.Models
{
    public class CategoryVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ArticleVM> Articles { get; set; }
    }
}
