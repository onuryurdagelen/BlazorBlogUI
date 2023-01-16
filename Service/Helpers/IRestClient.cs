using BlogBlazorUI.Results;

namespace BlogBlazorUI.Service.Helpers
{
    public interface IRestClient
    {
        Task<RestResponse<TResponse>> Add<TResponse>(TResponse root, string uri);
        Task<RestResponse<TResponse>> Update<TResponse>(TResponse root, string uri);
        Task<RestResponse<TResponse>> Action<TResponse>(string uri);
        Task<RestResponse<TResponse>> Get<TResponse>(string uri);
        Task<RestResponse<bool>> Delete(string uri);
        Task<RestResponse<TResponse>> UploadFile<TResponse>(Stream stream, string file_name, string uri);
        Task<RestResponse<bool>> DownloadFile(Stream stream, string uri);
    } // End of the interface
}
