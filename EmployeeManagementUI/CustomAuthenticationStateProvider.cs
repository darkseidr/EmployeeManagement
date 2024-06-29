using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly AuthService _authService;

    public CustomAuthenticationStateProvider(AuthService authService)
    {
        _authService = authService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var identity = await _authService.GetClaimsIdentity();

        var user = new ClaimsPrincipal(identity);
        return new AuthenticationState(user);
    }
}
