using ECommerce.Discount.Business.Services.Coupons;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Discount.Business.Extensions
{
    public static class BusinessRegistrations
    {

        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICouponService, CouponService>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
