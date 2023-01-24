using BlazorStrap.Shared.InternalComponents;
using BlogBlazorUI.Dtos;
using BlogBlazorUI.Models;
using BlogBlazorUI.Results;
using BlogBlazorUI.Service.Helpers;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace BlogBlazorUI.Service
{
    public class ArticleService
    {
        public static RestDataResponse<ArticleDto> ArticlesResponse { get; set; } 
        public static RestDataResponse<List<ArchivedArticleVM>> ArchivedArticlesResponse { get; set; }
        public static RestDataResponse<List<ArticleVM>> MostViewedArticlesResponse { get; set; }
        public static RestDataResponse<ArticleDto> ListOfArchivedArticlesResponse { get; set; }
        public static RestDataResponse<ArticleDto> ArticlesAsCategoryResponse { get; set; }
        public static RestDataResponse<ArticleVM> ArticleResponse { get; set; }
        public static RestDataResponse<AddArticleDto> AddArticleDtoResponse { get; set; }
        public static ErrorVM[] Errors { get; set; }

        public static async Task<bool> GetArticle(ApiHelper apihelper, string parameter)
        {

            bool result = false;
            ArticleResponse = new RestDataResponse<ArticleVM>();
            try
            {
                //Get the response
                HttpResponseMessage responseMessage = await apihelper.httpClient.GetAsync(parameter);

                //Check the status code for the response
                if (responseMessage.IsSuccessStatusCode)
                {
                    //Get string data
                    string data = await responseMessage.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    ArticleResponse = JsonConvert.DeserializeObject<RestDataResponse<ArticleVM>>(data);

                    result = true;
                }
                else
                {
                    //Get string data
                    string data = await responseMessage.Content.ReadAsStringAsync();
                    ArticleResponse = JsonConvert.DeserializeObject<RestDataResponse<ArticleVM>>(data);
                }

            }
            catch (Exception ex)
            {

                ArticleResponse.Error = $"Get: {parameter}. {ex.ToString()}";
                ArticleResponse.StatusCode = HttpStatusCode.BadRequest;
            }
            return result;
        }


        public static async Task<bool> GetArticles(ApiHelper apihelper, string parameter)
        {
   
            bool result = false;
            ArticlesResponse = new RestDataResponse<ArticleDto>();
            try
            {
                //Get the response
                HttpResponseMessage responseMessage = await apihelper.httpClient.GetAsync(parameter);

                //Check the status code for the response
                if (responseMessage.IsSuccessStatusCode)
                {
                    //Get string data
                    string data = await responseMessage.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    ArticlesResponse = JsonConvert.DeserializeObject<RestDataResponse<ArticleDto>>(data);

                    result = true;
                }
                else
                {
                    //Get string data
                    string data = await responseMessage.Content.ReadAsStringAsync();
                    ArticlesResponse = JsonConvert.DeserializeObject<RestDataResponse<ArticleDto>>(data);

                }

            }
            catch (Exception ex)
            {

                ArticlesResponse.Error = $"Get: {parameter}. {ex.ToString()}";
                ArticlesResponse.StatusCode = HttpStatusCode.BadRequest; 
            }
            return result;
        }

        public static async Task<bool> GetMostViewedArticles(ApiHelper apihelper, string parameter)
        {
   
            bool result = false;
            MostViewedArticlesResponse = new RestDataResponse<List<ArticleVM>>();
            try
            {
                //Get the response
                HttpResponseMessage responseMessage = await apihelper.httpClient.GetAsync(parameter);

                //Check the status code for the response
                if (responseMessage.IsSuccessStatusCode)
                {
                    //Get string data
                    string data = await responseMessage.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    MostViewedArticlesResponse = JsonConvert.DeserializeObject<RestDataResponse<List<ArticleVM>>>(data);

                    result = true;
                }
                else
                {
                    //Get string data
                    string data = await responseMessage.Content.ReadAsStringAsync();
                    MostViewedArticlesResponse = JsonConvert.DeserializeObject<RestDataResponse<List<ArticleVM>>>(data);
                }

            }
            catch (Exception ex)
            {

                MostViewedArticlesResponse.Error = $"Get: {parameter}. {ex.ToString()}";
                MostViewedArticlesResponse.StatusCode = HttpStatusCode.BadRequest;
            }
            return result;
        }

        public static async Task<bool> GetListOfArchivedArticles(ApiHelper apihelper,string parameter)
        {
   

            bool result = false;
            ListOfArchivedArticlesResponse = new RestDataResponse<ArticleDto>();
            try
            {
                //Get the response
                HttpResponseMessage responseMessage = await apihelper.httpClient.GetAsync(parameter);

                //Check the status code for the response
                if (responseMessage.IsSuccessStatusCode)
                {
                    //Get string data
                    string data = await responseMessage.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    ListOfArchivedArticlesResponse = JsonConvert.DeserializeObject<RestDataResponse<ArticleDto>>(data);

                    result = true;
                }
                else
                {
                    //Get string data
                    string data = await responseMessage.Content.ReadAsStringAsync();
                    ListOfArchivedArticlesResponse.StatusCode = responseMessage.StatusCode;
                }

            }
            catch (Exception ex)
            {

                ListOfArchivedArticlesResponse.Error = $"Get: {parameter}. {ex.ToString()}";
                ListOfArchivedArticlesResponse.StatusCode = HttpStatusCode.BadRequest;
            }
            return result;


        }


        public static async Task<bool> GetArchivedArticles(ApiHelper apihelper, string parameter)
        {


            bool result = false;
            ArchivedArticlesResponse = new RestDataResponse<List<ArchivedArticleVM>>();
            try
            {
                //Get the response
                HttpResponseMessage responseMessage = await apihelper.httpClient.GetAsync(parameter);

                //Check the status code for the response
                if (responseMessage.IsSuccessStatusCode)
                {
                    //Get string data
                    string data = await responseMessage.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    ArchivedArticlesResponse = JsonConvert.DeserializeObject<RestDataResponse<List<ArchivedArticleVM>>>(data);

                    result = true;
                }
                else
                {
                    //Get string data
                    string data = await responseMessage.Content.ReadAsStringAsync();
                    ArchivedArticlesResponse.StatusCode = responseMessage.StatusCode;
                }

            }
            catch (Exception ex)
            {

                ArchivedArticlesResponse.Error = $"Get: {parameter}. {ex.ToString()}";
                ArchivedArticlesResponse.StatusCode = HttpStatusCode.BadRequest;
            }
            return result;


        }


        public static async Task<bool> GetArticlesAsCategory(ApiHelper apihelper,string parameter)
        {
   
            bool result = false;
            ArticlesAsCategoryResponse = new RestDataResponse<ArticleDto>();
            try
            {
                //Get the response
                HttpResponseMessage responseMessage = await apihelper.httpClient.GetAsync(parameter);

                //Check the status code for the response
                if (responseMessage.IsSuccessStatusCode)
                {
                    //Get string data
                    string data = await responseMessage.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    ArticlesAsCategoryResponse = JsonConvert.DeserializeObject<RestDataResponse<ArticleDto>>(data);

                    result = true;
                }
                else
                {
                    //Get string data
                    string data = await responseMessage.Content.ReadAsStringAsync();
                    ListOfArchivedArticlesResponse.StatusCode = responseMessage.StatusCode;
                }

            }
            catch (Exception ex)
            {
                ListOfArchivedArticlesResponse.Error = $"Get: {parameter}. {ex.ToString()}";
                ListOfArchivedArticlesResponse.StatusCode = HttpStatusCode.BadRequest;
            }
            return result;


        }

        public static async Task<bool> AddArticle(ApiHelper apiHelper,object root,string parameter)
        {
            bool result = false;
            AddArticleDtoResponse = new RestDataResponse<AddArticleDto>();

            //Convert the post to json
            string json = JsonConvert.SerializeObject(root);

            //Send data as application/json data
            using (StringContent content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json))
            {
                try
                {
                    //Get the response

                    HttpResponseMessage response = await apiHelper.httpClient.PostAsync(parameter, content);
                    //Check the status code for the response

                    if (response.IsSuccessStatusCode)
                    {

                        //Get string data
                        string data = await response.Content.ReadAsStringAsync();
                        //Deserialize the data
                        AddArticleDtoResponse = JsonConvert.DeserializeObject<RestDataResponse<AddArticleDto>>(data);
                        result = true;

                    }
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        //Deserialize the data
                        AddArticleDtoResponse = JsonConvert.DeserializeObject<RestDataResponse<AddArticleDto>>(data);
                        AddArticleDtoResponse.StatusCode = response.StatusCode;
                    }
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        //Get string data
                        string data = await response.Content.ReadAsStringAsync();
                        Errors = System.Text.Json.JsonSerializer.Deserialize<ErrorVM[]>(data);
                        AddArticleDtoResponse.StatusCode = response.StatusCode;
                    }

                }
                catch (Exception ex)
                {

                    // Add exception data

                    AddArticleDtoResponse.Error = $"Add: {parameter}. {ex.ToString()}";
                    AddArticleDtoResponse.Message = "Internal Server Error";
                    AddArticleDtoResponse.StatusCode = HttpStatusCode.InternalServerError;
                }
                return result;
            }
        }
    }
}
