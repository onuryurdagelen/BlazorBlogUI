using BlogBlazorUI.Extensions;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace BlogBlazorUI.Service.Helpers
{
    public class ApiHelper
    {
        public HttpClient httpClient { get; set; }

        public ApiHelper()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7176/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
        }
    }
}
