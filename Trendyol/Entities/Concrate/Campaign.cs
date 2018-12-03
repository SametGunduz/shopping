using System;
using Trendyol.Entities.Abstract;

namespace Trendyol.Entities.Concrate
{
	public class Campaign : IDiscount
	{
		public Campaign(Category category, DiscountType discountType, decimal discountValue, int quantity)
		{
			this.Category = category;

			this.DiscountType = discountType;

			this.DiscountValue = discountValue;

			this.Quantity = quantity;
		}

		public Category Category { get; set; }

		public DiscountType DiscountType { get; set; }

		public decimal DiscountValue { get; set; }

		public int Quantity { get; set; }

    }
}
