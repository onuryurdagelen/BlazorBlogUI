using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json;
using System.Text;
using BlogBlazorUI.Results;
using BlogBlazorUI.Utils;
using System.Net.Http.Headers;
using System.Net;
using Newtonsoft.Json;
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

        public Task<Results.RestDataResponse<TResponse>> Action<TResponse>(string uri)
        {
            throw new NotImplementedException();
        }

        public Task<Results.RestDataResponse<bool>> Delete(string uri)
        {
            throw new NotImplementedException();
        }

        public Task<Results.RestDataResponse<bool>> DownloadFile(Stream stream, string uri)
        {
            throw new NotImplementedException();
        }

        public async Task<Results.RestDataResponse<TResponse>> Get<TResponse>(string uri)
        {
            //Create the response to return
            Results.RestDataResponse<TResponse> restResponse = new Results.RestDataResponse<TResponse>();

            try
            {
                //Get the response
                HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(uri);

                //Check the status code for the response
                if (response.IsSuccessStatusCode)
                {
                    //Get string data
                    string data = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    restResponse = JsonConvert.DeserializeObject<Results.RestDataResponse<TResponse>>(data);
                    restResponse.StatusCode = HttpStatusCode.OK;
                }
                else
                {
                    //Get string data
                    string data = await response.Content.ReadAsStringAsync();

                    restResponse.Error = $"Get: {uri}. {Regex.Unescape(data)}";
                    restResponse.StatusCode = response.StatusCode;
                }

            }
            catch (Exception ex)
            {

                restResponse.Error = $"Get: {uri}. {ex.ToString()}";
                restResponse.StatusCode = HttpStatusCode.BadRequest;
            }

            return restResponse;
        }

        public async Task<RestDataResponse<TResponse>> Post<TResponse>(object root, string uri)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //Convert the post to json
            string json = JsonConvert.SerializeObject(root, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            Results.RestDataResponse<TResponse> restResponse = new Results.RestDataResponse<TResponse>();

            //Send data as application/json data
            using (StringContent content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json))
            {
                try
                {
                    //Get the response

                    HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(uri, content);
                    //Check the status code for the response

                    if (response.IsSuccessStatusCode)
                    {

                        //Get string data
                        string data = await response.Content.ReadAsStringAsync();
                        await Console.Out.WriteLineAsync(data);
                        //Deserialize the data
                        restResponse = JsonConvert.DeserializeObject<Results.RestDataResponse<TResponse>>(data);
                        
                    }
                    else
                    {
                        //Get string data
                        string data = await response.Content.ReadAsStringAsync();
                        restResponse = JsonConvert.DeserializeObject<Results.RestDataResponse<TResponse>>(data);
                    }

                }
                catch (Exception ex)
                {

                    // Add exception data
                    restResponse.Error = $"Add: {uri}. {ex.ToString()}";
                }
            }

            //Return the response
            return restResponse;
        }

        public Task<Results.RestDataResponse<TResponse>> Update<TResponse>(TResponse root, string uri)
        {
            throw new NotImplementedException();
        }

        public Task<Results.RestDataResponse<TResponse>> UploadFile<TResponse>(Stream stream, string file_name, string uri)
        {
            throw new NotImplementedException();
        }
    }
}
