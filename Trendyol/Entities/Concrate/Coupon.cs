using System;
using Trendyol.Entities.Abstract;

namespace Trendyol.Entities.Concrate
{
	public class Coupon : IDiscount, ICoupon
	{
		public IDiscount Initialize(string code, DiscountType discountType, decimal discountValue, int quantity)
		{
			this.ValidateCoupon(code);

			this.DiscountType = discountType;

			this.DiscountValue = discountValue;

			this.Quantity = quantity;

			return this;

		}

		public DiscountType DiscountType { get; set; }

		public decimal DiscountValue { get; set; }

		public int Quantity { get; set; }

		public bool ValidateCoupon(string code)
		{
			if (code.Length != 4) throw new Exception("This coupon is not valid");

			return true;
		}

	}
}
