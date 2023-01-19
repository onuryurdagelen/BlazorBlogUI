using BlogBlazorUI.components.Client;
using BlogBlazorUI.Models;

namespace BlogBlazorUI.Dtos
{
    public class ArticleDto
    {
        public int TotalCount { get; set; }
        public List<ArticleVM> Articles { get; set; }
    }
}
