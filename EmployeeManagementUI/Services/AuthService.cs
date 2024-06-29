
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using EmployeeManagement.Shared.Models;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;



public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IJSRuntime _jsRuntime;
    public AuthService(HttpClient httpClient, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _jsRuntime = jsRuntime;
        }

        public async Task<string> Login(LoginModel loginModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginModel);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<TokenResponse>();
                return result.Token;
            }
            return null;
        }
 
    public async Task<ClaimsIdentity> GetClaimsIdentity()
    {
        var authToken = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", "authToken");

        if (!string.IsNullOrEmpty(authToken))
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(authToken);

            var claims = token.Claims;

            var identity = new ClaimsIdentity(claims, "jwt");

            return identity;
        }
        else
        {
            // Handle case where authToken is null or empty (e.g., user not authenticated)
            return new ClaimsIdentity();
        }
    }



}

public class TokenResponse
    {
        public string Token { get; set; }
    }



