using BlogBlazorUI.Models;
using BlogBlazorUI.Utils;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Diagnostics;
using System.Net.Http.Json;

namespace BlogBlazorUI.Pages.Client
{
    public class IndexBase:ComponentBase
    {
        [Inject]
        HttpClient HttpClient { get; set; }
      
        public List<ArticleVM> Articles { get; set; }

        public ArticleVM ArticleVM { get; set; }

        public int articleId { get; set; }

        public int pageIndex { get; set; } = 1;

        [Parameter]
        public int index { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public int pageCount { get; set; } = 5;

        public int paginationCount { get; set; }

        public string ErrorMessage { get; set; }

        public int TotalCount { get; set; }

        public int counter { get; set; } = 1;
        //public bool shouldRender { get; set; } = false;

        protected  async Task OnPageClick(int pageIndex)
        {
            this.Articles = null;
            this.pageIndex = pageIndex;
            this.index = pageIndex;
            System.Console.WriteLine($"PageIndex: {pageIndex}");
            NavigationManager.NavigateTo($"/page/{pageIndex}");
        }
        protected async Task getArticlesAsPaginately(int pageIndex)
        {
            var result = await HttpClient.GetFromJsonAsync<RestResponse<List<ArticleVM>>>($"articles/{pageIndex}/{this.pageCount}");

            if (result == null)
            {
                ErrorMessage = "Hata!";
            }
            else
            {
                this.Articles = result.Data;
                TotalCount = result.TotalCount;
  
            }
            StateHasChanged();

        }

        protected override async Task OnInitializedAsync()
        {
           
            paginationCount = this.pageCount;
            await getArticlesAsPaginately(this.pageIndex);
   
            if (TotalCount % pageCount != 0)
            {
                this.paginationCount+=1;
            }
            StateHasChanged();
        }
        protected override async Task OnParametersSetAsync()
        {
            System.Console.WriteLine("Parametre değişti");
            this.Articles = null;
            if (this.index == 0)
            {
                this.pageIndex = 1;
               
            }
            await getArticlesAsPaginately(this.pageIndex);
            StateHasChanged();
        }

    }
}
