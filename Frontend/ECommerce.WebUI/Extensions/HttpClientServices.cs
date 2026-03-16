using ECommerce.WebUI.Services.CatalogServices.CategoryServices;
using ECommerce.WebUI.Services.DiscountServices.CouponServices;
using ECommerce.WebUI.Settings;

namespace ECommerce.WebUI.Extensions
{
    public static class HttpClientServices
    {

        public static void AddHttpClientServicesExtensions(this IServiceCollection services,
                                                                IConfiguration configuration)
        {

            services.Configure<ServiceApiSettings>(configuration.GetSection(nameof(ServiceApiSettings)));



            var apiSettings = configuration.GetSection(nameof(ServiceApiSettings)).Get<ServiceApiSettings>();


            services.AddHttpClient<ICategoryService, CategoryService>(client =>
            {
                client.BaseAddress =  new Uri(apiSettings.Catalog.Path);
            });

            services.AddHttpClient<ICouponService, CouponService>(client =>
            {
                client.BaseAddress = new Uri(apiSettings.Discount.Path);
            });

            
        }


    }
}
