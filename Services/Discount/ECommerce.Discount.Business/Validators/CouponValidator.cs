using ECommerce.Discount.Entity.Entities;
using FluentValidation;

namespace ECommerce.Discount.Business.Validators
{
    public class CouponValidator: AbstractValidator<Coupon>
    {
        public CouponValidator()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Kod boş olamaz.");
            RuleFor(x => x.DiscountRate).NotEmpty().WithMessage("İndirim Oranı boş olamaz.");
            RuleFor(x => x.ExpireDate).NotEmpty().WithMessage("Son Geçerlilik Tarihi boş olamaz.");
        }
    }
}
