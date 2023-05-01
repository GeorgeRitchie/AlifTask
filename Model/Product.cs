using AlifTask.Common;

namespace AlifTask.Model
{
	internal class Product
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public ProductCategory Category { get; set; }

		// I'd like to add product price to this class as below
		// public double Price { get; set; }
	}
}
