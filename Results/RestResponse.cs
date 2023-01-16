using BlogBlazorUI.Utils;
using System.Net;
using System.Text.Json;

namespace BlogBlazorUI.Results
{
    public class RestResponse<TResponse> : IRestResponse<TResponse>
    {
        #region Variables
        public TResponse Data { get; set; }
        public string Error { get; set; }
        public bool IsSuccess { get; set; } 
        public HttpStatusCode StatusCode { get; set; }
        #endregion

        #region Constructors
        public RestResponse()
        {
            // Set values for instance variables
            this.Data = default(TResponse);
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
