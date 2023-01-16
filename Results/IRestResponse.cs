using System.Net;

namespace BlogBlazorUI.Results
{
    public class IRestResponse<TResponse>
    {
        public TResponse Data { get; }
        public string Error { get; }
        public bool IsSuccess { get; }
        public HttpStatusCode StatusCode { get; }
    }
}
