using BlogBlazorUI.Results;

namespace BlogBlazorUI.Service.Helpers
{
    public interface IRestClient
    {
        Task<RestDataResponse<TResponse>> Post<TResponse>(object root, string uri);
        Task<RestDataResponse<TResponse>> Update<TResponse>(TResponse root, string uri);
        Task<RestDataResponse<TResponse>> Action<TResponse>(string uri);
        Task<RestDataResponse<TResponse>> Get<TResponse>(string uri);
        Task<RestDataResponse<bool>> Delete(string uri);
        Task<RestDataResponse<TResponse>> UploadFile<TResponse>(Stream stream, string file_name, string uri);
        Task<RestDataResponse<bool>> DownloadFile(Stream stream, string uri);
    } // End of the interface
}
