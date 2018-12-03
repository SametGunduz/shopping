using System;
using System.Collections.Generic;
using System.Linq;
using Trendyol.Helpers;

namespace Trendyol.Entities.Concrate
{
	public class ShoppingCart
	{
		public ShoppingCart()
		{
			Products = new List<Product>();
		}

		public List<Product> Products { get; set; }

		public int TotalItems { get { return this.Products.Sum(p => p.Quantity); } }

		public decimal TotalAmount { get { return this.Products.Sum(p => p.UnitPrice); } }

		public decimal TotalCoupon { get; set; }

		public decimal DeliveryCost { get; set; }

		public decimal TotalDiscount { get { return (this.Products.Sum(p => p.CampaignDistanceAmount) + this.Products.Sum(p => p.CouponDistanceAmount)); } }

        public decimal TotalAmountAfterDistance { get { return ((this.Products.Sum(p => p.UnitPrice) - this.Products.Sum(p => p.CampaignDistanceAmount)) - this.TotalCoupon); } }

		public int NumberOfDeliveries { get { return this.Products.GroupBy(a => a.Category.Title).Select(g => new { g.Key, Count = g.Count() }).Sum(i => i.Count); } }

		public int NumberOfProducts { get { return this.Products.GroupBy(a => a.Title).Select(g => new { g.Key, Count = g.Count() }).Sum(i => i.Count); } }

		public void Print()
		{
			var table = new List<string[]>();

			var titles = new string[6]; titles[0] = "Category"; titles[1] = "Product"; titles[2] = "Quantity"; titles[3] = "Unit Price"; titles[4] = "Amount"; titles[5] = "Amount Paid";

			table.Add(titles);

			foreach (var item in this.Products)
			{

				var data = new string[6]; data[0] = item.Category.Title; data[1] = item.Title; data[2] = item.Quantity.ToString("N0"); data[3] = item.UnitPrice.ToString("N0"); data[4] = (item.UnitPrice * item.Quantity).ToString("N0"); data[5] = (item.CampaignDistanceAmount + item.CouponDistanceAmount).ToString("N0");

				table.Add(data);
			}

			Console.WriteLine(ArrayPrinter.GetDataInTableFormat(table));

			Console.WriteLine(Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.DarkRed;

			Console.WriteLine(String.Format("-Delivery: {0:N0} TL", DeliveryCost));

			Console.WriteLine(String.Format("-Coupon : {0:N0} TL ", TotalCoupon));

			Console.WriteLine(String.Format("-Total Discount : {0:N0} TL", TotalDiscount));

			Console.WriteLine(String.Format("-Total Amount : {0:N0} TL", TotalAmount));

			Console.WriteLine(String.Format("-Total Amount Paid : {0:N0} TL ", TotalAmountAfterDistance - DeliveryCost));

			Console.ReadKey();
		}

	}
}
