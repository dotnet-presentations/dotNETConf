using BlazorClientAD.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorClientAD
{
    public class CustomAuthenticationProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        public CustomAuthenticationProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public override async Task<AuthenticationState>
            GetAuthenticationStateAsync()
        {
            ClaimsPrincipal user;

            // Call the GetUser method to get the status
            // This only sets things like the AuthorizeView
            // and the AuthenticationState CascadingParameter
            var result =
                await _httpClient.GetJsonAsync<BlazorUser>("api/user/GetUser");

            // Was a UserName returned?
            if (result.UserName != "")
            {
                // Create a ClaimsPrincipal for the user
                var identity = new ClaimsIdentity(new[]
                {
                   new Claim(ClaimTypes.Name, result.UserName),
                }, "AzureAdAuth");

                user = new ClaimsPrincipal(identity);
            }
            else
            {
                user = new ClaimsPrincipal(); // Not logged in
            }

            return await Task.FromResult(new AuthenticationState(user));
        }
    }
}
