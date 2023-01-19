using System.Net;

namespace BlogBlazorUI.Results
{
    public class RestResponse : IRestResponse
    {
        public string Error { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
