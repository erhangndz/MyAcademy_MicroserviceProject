using ECommerce.WebUI.DTOs.IdentityServer;

namespace ECommerce.WebUI.Services.IdentityServices
{
    public interface IIdentityService
    {
        Task<bool> LoginAsync(LoginDto loginDto);
    }
}
