using BlogBlazorUI.Utils;
using System.Net;
using System.Text.Json;

namespace BlogBlazorUI.Results
{
    public class RestDataResponse<TResponse> : IRestDataResponse<TResponse>
    {
        #region Variables
        public TResponse Data { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        #endregion

        #region Constructors
        public RestDataResponse()
        {
            // Set values for instance variables
            Type type = typeof(TResponse);
            Data = (TResponse)Activator.CreateInstance(type); //Requires parameterless constructor.
            this.Error = null;
            this.IsSuccess = false;
        } // End of the constructor
        #endregion

        #region Get methods
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        } // End of the ToString method
        #endregion
    } // End of the class
}
