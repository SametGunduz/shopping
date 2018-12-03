using System;
using Trendyol.Entities.Abstract;

namespace Trendyol.Services.Abstract
{
	public interface IDiscountCalculator
	{
		decimal Calculate(IDiscount discounts, int categoryQuantity, decimal unitPrice);
	}
}
