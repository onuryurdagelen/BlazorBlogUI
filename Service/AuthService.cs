using BlazorStrap.Shared.InternalComponents;
using BlogBlazorUI.Dtos;
using BlogBlazorUI.Models;
using BlogBlazorUI.Results;
using BlogBlazorUI.Service.Helpers;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace BlogBlazorUI.Service
{
    public static class AuthService
    {
        public static RestDataResponse<TokenDto> TokenResponse { get; set; }  
        public static RestDataResponse<UserRegisterDto> RegisterResponse { get; set; }
        public static ErrorVM[] Errors { get; set; }  

        public async static Task<bool> Login(ApiHelper apiHelper,object root,string parameter)
        {
            bool result = false;
            TokenResponse = new RestDataResponse<TokenDto>();

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
                        TokenResponse = JsonConvert.DeserializeObject<RestDataResponse<TokenDto>>(data);
                        result = true;

                    }
                    if(response.StatusCode == HttpStatusCode.NotFound)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        //Deserialize the data
                        TokenResponse = JsonConvert.DeserializeObject<RestDataResponse<TokenDto>>(data);
                        TokenResponse.StatusCode = response.StatusCode;
                    }
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        //Get string data
                        string data = await response.Content.ReadAsStringAsync();
                        Errors = System.Text.Json.JsonSerializer.Deserialize<ErrorVM[]>(data);
                        TokenResponse.StatusCode = response.StatusCode;
                    }

                }
                catch (Exception ex)
                {

                    // Add exception data

                    TokenResponse.Error = $"Add: {parameter}. {ex.ToString()}";
                    TokenResponse.Message = "Internal Server Error";
                    TokenResponse.StatusCode = HttpStatusCode.InternalServerError;
                }
                return result;
            }
        }

        public async static Task<bool> Register(ApiHelper apiHelper, object root, string parameter)
        {
            bool result = false;
            RegisterResponse = new RestDataResponse<UserRegisterDto>();

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
                        RegisterResponse = JsonConvert.DeserializeObject<RestDataResponse<UserRegisterDto>>(data);
                        result = true;

                    }
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        //Deserialize the data
                        RegisterResponse = JsonConvert.DeserializeObject<RestDataResponse<UserRegisterDto>>(data);
                    }
                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        //Get string data
                        string data = await response.Content.ReadAsStringAsync();
                        Errors = JsonConvert.DeserializeObject<ErrorVM[]>(data);
                        RegisterResponse.StatusCode = response.StatusCode;
                    }

                }
                catch (Exception ex)
                {

                    // Add exception data
                    RegisterResponse.Error = $"Add: {parameter}. {ex.ToString()}";
                    RegisterResponse.StatusCode = HttpStatusCode.InternalServerError;
                    TokenResponse.Message = "Internal Server Error";
                }
                return result;
            }
        }
    }
}
