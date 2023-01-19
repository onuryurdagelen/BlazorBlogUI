using System.Net;

namespace BlogBlazorUI.Results
{
    public interface IRestResponse
    {
        string Error { get; set; }
        bool IsSuccess { get; set; }
        HttpStatusCode StatusCode { get; set; }
    }
}
