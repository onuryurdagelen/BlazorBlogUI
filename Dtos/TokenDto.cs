namespace BlogBlazorUI.Dtos
{
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime ExpirationTime { get; set; }
        public string RefreshToken { get; set; }
    }
}
