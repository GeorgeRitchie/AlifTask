using AlifTask.Common;
using AlifTask.Model;

namespace AlifTask
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Server server = new Server();

			Customer customer = new Customer();
			Product product = default!;

			Console.WriteLine("Welcome!");

			Console.Write("Enter your name: ");
			customer.Name = Console.ReadLine()!;

			Console.Write("Enter your phone number: ");
			customer.PhoneNumber = Console.ReadLine()!;

			Console.Write("Choose phoduct phone (p), laptop (l), TV (t): ");
			string productType = Console.ReadLine()!;

			if (productType == "p")
				product = new Product() { Name = "Phone", Category = ProductCategory.Phone };
			else if (productType == "l")
				product = new Product() { Name = "Laptop", Category = ProductCategory.LapTop };
			else if (productType == "t")
				product = new Product() { Name = "TV", Category = ProductCategory.TV };

			Console.WriteLine("Enter number of product installment months: ");
			int installmentMonths = int.Parse(Console.ReadLine()!);

			// this should do seller
			Console.WriteLine("Enter product price: ");
			double productPrice = double.Parse(Console.ReadLine()!);

			var totalPayment = server.GetTotalPrice(product, productPrice, installmentMonths);
			Console.WriteLine($"Your total payment: {totalPayment} TJS");

			Console.WriteLine();
			Console.Write("Do you want to buy? (y/n): ");
			if (Console.ReadLine() == "y")
				server.PayPayment($"Payment: {totalPayment} TJS", customer);
		}
	}
}