using Duende.IdentityModel.Client;
using ECommerce.WebUI.DTOs.IdentityServer;
using ECommerce.WebUI.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace ECommerce.WebUI.Services.IdentityServices
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _client;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;
        private readonly IHttpContextAccessor _contextAccessor;

        public IdentityService(HttpClient client,
                               IOptions<ClientSettings> clientSettings,
                               IOptions<ServiceApiSettings> serviceApiSettings,
                               IHttpContextAccessor contextAccessor)
        {
            _client = client;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
            _contextAccessor = contextAccessor;
        }
        public async Task<bool> LoginAsync(LoginDto loginDto)
        {
            var discoveryEndpoint = await _client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl
            });

            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.AdminClient.ClientId,
                ClientSecret = _clientSettings.AdminClient.ClientSecret,
                UserName = loginDto.Username,
                Password = loginDto.Password,
                Address = discoveryEndpoint.TokenEndpoint
            };

            var token = await _client.RequestPasswordTokenAsync(passwordTokenRequest);

            if(token.AccessToken is null)
            {
                return false;
            }

            var userInfoRequest = new UserInfoRequest
            {
                Address = discoveryEndpoint.UserInfoEndpoint,
                Token = token.AccessToken
            };

            var userValues = await _client.GetUserInfoAsync(userInfoRequest);

            var claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProps = new AuthenticationProperties();

            authProps.StoreTokens(new List<AuthenticationToken>
            {
                new AuthenticationToken
                {
                    Name= "AccessToken",
                    Value= token.AccessToken
                }
            });

            authProps.IsPersistent = false;

            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProps);

            return true;
            


        }
    }
}
