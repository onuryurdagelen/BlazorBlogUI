using BlogBlazorUI.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;

namespace BlogBlazorUI.Dtos
{
    public class AddArticleDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public UploadedFileDto UploadedFile { get; set; }
        public int CategoryId { get; set; }

    }
}
