using ECommerce.Discount.DataAccess.Context;
using ECommerce.Discount.DataAccess.Repositories.GenericRepositories;
using ECommerce.Discount.Entity.Entities;

namespace ECommerce.Discount.DataAccess.Repositories.Coupons
{
    public class CouponRepository : GenericRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(AppDbContext _context) : base(_context)
        {
        }
    }
}
