using ECommerce.Discount.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Discount.DataAccess.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Coupon> Coupons { get; set; }

    }
}
