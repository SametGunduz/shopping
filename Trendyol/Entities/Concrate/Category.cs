using System;
namespace Trendyol.Entities.Concrate
{
	public class BaseCategory
	{
		public string Title { get; set; }
	}

	public class Category : BaseCategory
	{
		public Category(string title)
		{
			this.Title = title;
		}

        public new string Title { get; set; }
    }
}
