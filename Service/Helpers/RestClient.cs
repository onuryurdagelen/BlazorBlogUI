using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json;
using System.Text;
using BlogBlazorUI.Results;
using BlogBlazorUI.Utils;
using System.Net.Http.Headers;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace BlogBlazorUI.Service.Helpers
{
    public class RestClient : IRestClient
    {
        public RestClient()
        {
            ApiHelper.InitializeClient();
        }

        public Task<Results.RestResponse<TResponse>> Action<TResponse>(string uri)
        {
            throw new NotImplementedException();
        }

        public Task<Results.RestResponse<TResponse>> Add<TResponse>(TResponse root, string uri)
        {
            throw new NotImplementedException();
        }

        public Task<Results.RestResponse<bool>> Delete(string uri)
        {
            throw new NotImplementedException();
        }

        public Task<Results.RestResponse<bool>> DownloadFile(Stream stream, string uri)
        {
            throw new NotImplementedException();
        }

        public Task<Results.RestResponse<TResponse>> Get<TResponse>(string uri)
        {
            throw new NotImplementedException();
        }

        public Task<Results.RestResponse<TResponse>> Update<TResponse>(TResponse root, string uri)
        {
            throw new NotImplementedException();
        }

        public Task<Results.RestResponse<TResponse>> UploadFile<TResponse>(Stream stream, string file_name, string uri)
        {
            throw new NotImplementedException();
        }
    }
}
