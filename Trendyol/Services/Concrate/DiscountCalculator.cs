using Trendyol.Entities.Abstract;
using Trendyol.Services.Abstract;

namespace Trendyol.Services.Concrate
{
	public class DiscountCalculator
	{
		private readonly IDiscountCalculator _discountCalculator;

		public DiscountCalculator(IDiscountCalculator discountCalculator)
		{
			_discountCalculator = discountCalculator;
		}

		public decimal Calculate(IDiscount discounts, int categoryQuantity, decimal unitPrice)
		{
			return _discountCalculator.Calculate(discounts, categoryQuantity, unitPrice);
		}
	}
}
