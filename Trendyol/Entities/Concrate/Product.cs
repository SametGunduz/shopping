using System;
namespace Trendyol.Entities.Concrate
{
	public class Product
	{
		public Product(string title, Category category, decimal unitPrice, int quantity)
		{
			this.Category = category;

			this.Title = title;

			this.UnitPrice = unitPrice;

			this.Quantity = quantity;
		}

		public Category Category { get; set; }

		public string Title { get; set; }

		public int Quantity { get; set; }

		public decimal UnitPrice { get; set; }

		public decimal CampaignDistanceAmount { get; set; }

		public decimal CouponDistanceAmount { get; set; }
	}
}
