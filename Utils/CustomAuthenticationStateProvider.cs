using Blazored.LocalStorage;
using BlogBlazorUI.Dtos;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace BlogBlazorUI.Utils
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal();
        private readonly HttpClient _httpClient;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService,HttpClient httpClient)
        {
            _localStorageService = localStorageService;
            _httpClient = httpClient;
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string authToken = await _localStorageService.GetItemAsStringAsync("authToken");

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();
            _httpClient.DefaultRequestHeaders.Authorization = null;

            //token var ise
            if(!string.IsNullOrEmpty(authToken))
            {
                try {
                    claimsIdentity = new ClaimsIdentity(ParseClaimsFromJwt(authToken),"jwt");
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken.Replace("\"", ""));
                } 
                catch 
                {
                    await _localStorageService.RemoveItemAsync("authToken");
                    claimsIdentity = new ClaimsIdentity();
                }
            }

            ClaimsPrincipal user = new ClaimsPrincipal(claimsIdentity);
            AuthenticationState state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
        public List<Claim> ParseJwtToken(string jwtToken)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtSecurityToken = jwtTokenHandler.ReadJwtToken(jwtToken);
            var claims = jwtSecurityToken.Claims.ToList();

            return claims;
        }
        private byte[] ParseBase64WithoutPadding(string base64Token)
        {
            switch (base64Token.Length % 4)
            {
                case 2: base64Token += "=="; break;
                case 3: base64Token += "="; break;
            }
            return Convert.FromBase64String(base64Token);
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            string payload = jwt.Split('.')[1];
            byte[] jsonBytes = ParseBase64WithoutPadding(payload);
            string jsonString = System.Text.Encoding.UTF8.GetString(jsonBytes); var keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

            var claims = keyValuePairs.Select(x => new Claim(x.Key, x.Value.ToString()));

            return claims;
        }

        public async Task UpdateAuthenticationStateAsync(List<AppClaimDto> claimList,TokenDto tokenDto)
        {
            ClaimsPrincipal claimsPrincipal;

            if(claimList != null)
            {
                List<Claim> claims = new List<Claim>();

                claimList.ForEach(x =>
                {
                    claims.Add(new Claim(x.ClaimType, x.ClaimValue));
                });

                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims));
                //tokenDto.ExpirationTime = DateTime.Now.AddSeconds(6000);
                await _localStorageService.SaveItemEncryptedAsync("authToken", tokenDto);
            }
            else
            {
                claimsPrincipal = _anonymous;
                await _localStorageService.RemoveItemAsync("authToken");
            }
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
        public async Task<string> GetToken()
        {
            string result = string.Empty;

            try
            {
                TokenDto userAuth = await _localStorageService.ReadEncryptedItemAsync<TokenDto>("authToken");

                if(userAuth != null && DateTime.Now < userAuth.ExpirationTime) 
                {
                    result = userAuth.AccessToken;
                }
            }
            catch {}
            return result;
        }
    }
}
