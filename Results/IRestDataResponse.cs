using System.Net;

namespace BlogBlazorUI.Results
{
    public class IRestDataResponse<TResponse>
    {
        TResponse Data { get; }
        string Error { get; }
        bool IsSuccess { get; }
        HttpStatusCode StatusCode { get; }
    }
}
