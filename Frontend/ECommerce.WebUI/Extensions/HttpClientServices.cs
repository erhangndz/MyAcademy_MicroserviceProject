using ECommerce.WebUI.Services.CatalogServices.CategoryServices;
using ECommerce.WebUI.Services.DiscountServices.CouponServices;
using ECommerce.WebUI.Services.IdentityServices;
using ECommerce.WebUI.Settings;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ECommerce.WebUI.Extensions
{
    public static class HttpClientServices
    {

        public static void AddHttpClientServicesExtensions(this IServiceCollection services,
                                                                IConfiguration configuration,IHttpContextAccessor httpContextAccessor)
        {

            services.Configure<ServiceApiSettings>(configuration.GetSection(nameof(ServiceApiSettings)));

            services.Configure<ClientSettings>(configuration.GetSection(nameof(ClientSettings)));



            var apiSettings = configuration.GetSection(nameof(ServiceApiSettings)).Get<ServiceApiSettings>();

            
          

            services.AddHttpClient<ICategoryService, CategoryService>(client =>
            {
                var accessToken = httpContextAccessor.HttpContext.GetTokenAsync("AccessToken").Result;
                if (accessToken != null)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
                client.BaseAddress =  new Uri(apiSettings.ApiGatewayUrl+apiSettings.Catalog.Path);
               
            });

            services.AddHttpClient<ICouponService, CouponService>(client =>
            {
                client.BaseAddress = new Uri(apiSettings.ApiGatewayUrl+apiSettings.Discount.Path);
            });

            services.AddHttpContextAccessor();
            services.AddHttpClient<IIdentityService, IdentityService>();

            
        }


    }
}
