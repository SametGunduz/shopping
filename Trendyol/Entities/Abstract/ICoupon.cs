using System;
using Trendyol.Entities.Concrate;

namespace Trendyol.Entities.Abstract
{
	public interface ICoupon
	{
		IDiscount Initialize(string code, DiscountType discountType, decimal discountValue, int quantity);

		bool ValidateCoupon(string code);
	}
}
