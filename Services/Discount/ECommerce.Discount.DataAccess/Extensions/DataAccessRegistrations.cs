using ECommerce.Discount.DataAccess.Context;
using ECommerce.Discount.DataAccess.Repositories.Coupons;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Discount.DataAccess.Extensions
{
    public static class DataAccessRegistrations
    {

        public static void AddDataAccess(this IServiceCollection services,
                                              IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddScoped<ICouponRepository, CouponRepository>();
        }


    }
}
