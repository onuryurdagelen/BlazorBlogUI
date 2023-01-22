using BlogBlazorUI.components.Client;

namespace BlogBlazorUI.Models
{
    public class CategoryVM
    {
        public CategoryVM()
        {
            Articles = new HashSet<ArticleVM>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string text => string.Format("{0} - {1}", Id, Name);

        public virtual ICollection<ArticleVM> Articles { get; set; }
    }
}
