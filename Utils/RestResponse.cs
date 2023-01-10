namespace BlogBlazorUI.Utils
{
    public class RestResponse<T> where T : class
    {
        public T Data { get; set; }
        public int TotalCount { get; set; }
        public bool IsSuccess { get; set; }

    }
}
