using Trendyol.Entities.Abstract;
using Trendyol.Entities.Concrate;
using Trendyol.Services.Abstract;

namespace Trendyol.Services.Concrate
{
	public class CouponDiscountCalculator : IDiscountCalculator
	{
		public decimal Calculate(IDiscount discounts, int categoryQuantity, decimal unitPrice)
		{
			decimal result = 0;

			if (discounts.GetType() == typeof(Coupon))
			{
				if (categoryQuantity >= discounts.Quantity)
				{
					result = (unitPrice / 100) * discounts.DiscountValue;
				}
			}
			return result;
		}

	}
}
